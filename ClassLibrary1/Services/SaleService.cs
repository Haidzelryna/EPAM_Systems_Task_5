using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class SaleService : IService<DAL.Sale>
    {
        private readonly IGenericRepository<DAL.Sale> _saleRepository;
        private readonly IMapper _mapper;

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public SaleService(IMapper mapper)
        {
            _saleRepository = new GenericRepository<DAL.Sale>();
            _mapper = mapper;
        }

        public SaleService(IMapper mapper, IGenericRepository<DAL.Sale> saleRepository)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DAL.Sale>> GetAllAsync()
        {
            IEnumerable<DAL.Sale> result = Enumerable.Empty<DAL.Sale>();
            await _locker.LockAsync(async () =>
            {
                result = await _saleRepository.GetAllAsync();
            });
            return result;
        }

        public async Task<DAL.Sale> FindAsync(Guid Id)
        {
            DAL.Sale result = new DAL.Sale();
            await _locker.LockAsync(async () =>
            {
                result = await _saleRepository.FindAsync(Id);
            });
            return result;
        }

        public void Add(DAL.Sale Entity)
        {
            _saleRepository.Add(Entity);
        }

        public void Add(IEnumerable<DAL.Sale> Entities)
        {
            _saleRepository.Add(Entities);
        }

        public void Remove(DAL.Sale Entity)
        {
            _saleRepository.Delete(Entity);
        }

        public void Remove(IEnumerable<DAL.Sale> Entities)
        {
            _saleRepository.Delete(Entities);
        }

        public async Task SaveChangesAsync()
        {
            await _saleRepository.SaveChangesAsync();
        }
    }
}

