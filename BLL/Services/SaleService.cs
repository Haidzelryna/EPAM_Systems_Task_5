using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class SaleService : IService<BLL.Sale>
    {
        private readonly IGenericRepository<DAL.Sale> _saleRepository;
        private readonly IMapper _mapper;

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public SaleService(IMapper mapper)
        {

        }

        public SaleService(IMapper mapper, IGenericRepository<DAL.Sale> saleRepository)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BLL.Sale>> GetAllAsync()
        {
            IEnumerable<DAL.Sale> dalEntities = Enumerable.Empty<DAL.Sale>();
            await _locker.LockAsync(async () =>
            {
                dalEntities = await _saleRepository.GetAllAsync();
            });
            return _mapper.Map<IEnumerable<BLL.Sale>>(dalEntities);
        }

        public async Task<BLL.Sale> FindAsync(Guid Id)
        {
            DAL.Sale dalEntity = new DAL.Sale();
            await _locker.LockAsync(async () =>
            {
                dalEntity = await _saleRepository.FindAsync(Id);
            });
            return _mapper.Map<BLL.Sale>(dalEntity);
        }

        public void Add(BLL.Sale Entity)
        {
            var dalEntity = _mapper.Map<DAL.Sale>(Entity);
            (dalEntity as DAL.BaseEntity).CreatedByUserId = Entity.CreatedByUserId;
            (dalEntity as DAL.BaseEntity).CreatedDateTime = Entity.CreatedDateTime;
            _saleRepository.Add(dalEntity);
        }

        public void Remove(BLL.Sale Entity)
        {
            var dalEntity = _mapper.Map<DAL.Sale>(Entity);
            _saleRepository.Delete(dalEntity);
        }

        public async Task SaveChangesAsync()
        {
            await _saleRepository.SaveChangesAsync();
        }

        public async void Update(BLL.Sale Entity)
        {
            var dalEntity = _mapper.Map<DAL.Sale>(Entity);
            var dalEntityFind = await _saleRepository.FindAsync(Entity.Id);
            Copy(dalEntityFind, dalEntity);
        }

        public void Copy(DAL.Sale target, DAL.Sale source)
        {
            target.ClientId = source.ClientId;
            target.ProductId = source.ProductId;
            target.ClientId = source.ClientId;
            target.Date = source.Date;
            target.Sum = source.Sum;
            target.CreatedByUserId = source.CreatedByUserId;
            target.CreatedDateTime = source.CreatedDateTime;
        }
    }
}

