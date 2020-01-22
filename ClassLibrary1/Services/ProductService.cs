using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class ProductService : IService<BLL.Product>
    {
        private readonly IGenericRepository<DAL.Product> _productRepository;
        private readonly IMapper _mapper;

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public ProductService(IMapper mapper)
        {
            _productRepository = new GenericRepository<DAL.Product>();
            _mapper = mapper;
        }

        public ProductService(IMapper mapper, IGenericRepository<DAL.Product> productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BLL.Product>> GetAllAsync()
        {
            IEnumerable<DAL.Product> dalEntities = Enumerable.Empty<DAL.Product>();
            await _locker.LockAsync(async () =>
            {
                dalEntities = await _productRepository.GetAllAsync();
            });
            return _mapper.Map<IEnumerable<BLL.Product>>(dalEntities);
        }

        public async Task<BLL.Product> FindAsync(Guid Id)
        {
            DAL.Product dalEntity = new DAL.Product();
            await _locker.LockAsync(async () =>
            {
                dalEntity = await _productRepository.FindAsync(Id);
            });
            return _mapper.Map<BLL.Product>(dalEntity);
        }

        public void Add(BLL.Product Entity)
        {
            var dalEntity = _mapper.Map<DAL.Product>(Entity);
            _productRepository.Add(dalEntity);
        }

        public void Add(IEnumerable<BLL.Product> Entities)
        {
            var dalEntities = _mapper.Map<IEnumerable<DAL.Product>>(Entities);
            _productRepository.Add(dalEntities);
        }

        public void Remove(BLL.Product Entity)
        {
            var dalEntity = _mapper.Map<DAL.Product>(Entity);
            _productRepository.Delete(dalEntity);
        }

        public void Remove(IEnumerable<BLL.Product> Entities)
        {
            var dalEntities = _mapper.Map<IEnumerable<DAL.Product>>(Entities);
            _productRepository.Delete(dalEntities);
        }

        public async Task SaveChangesAsync()
        {
            await _productRepository.SaveChangesAsync();
        }
    }
}

