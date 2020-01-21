using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class ProductService : IService<DAL.Product>
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

        public async Task<IEnumerable<DAL.Product>> GetAllAsync()
        {
            IEnumerable<DAL.Product> result = Enumerable.Empty<DAL.Product>();
            await _locker.LockAsync(async () =>
            {
                result = await _productRepository.GetAllAsync();
            });
            return result;
        }

        public async Task<DAL.Product> FindAsync(Guid Id)
        {
            DAL.Product result = new DAL.Product();
            await _locker.LockAsync(async () =>
            {
                result = await _productRepository.FindAsync(Id);
            });
            return result;
        }

        public async Task<bool> Check(IEnumerable<string> productsCheck)
        {
            IEnumerable<DAL.Product> products = await GetAllAsync();
            foreach (string productName in productsCheck)
            {
                if (products.Select(p => p.Name).ToList().Contains(productName) == false)
                {
                    return false;
                };
            }
            return true;
        }

        public void Remove(DAL.Product Entity)
        {
            _productRepository.Delete(Entity);
        }

        public void Remove(IEnumerable<DAL.Product> Entities)
        {
            _productRepository.Delete(Entities);
        }

        public void Add(DAL.Product Entity)
        {
            _productRepository.Add(Entity);
        }

        public void Add(IEnumerable<DAL.Product> Entities)
        {
            _productRepository.Add(Entities);
        }

        public async Task SaveChangesAsync()
        {
            await _productRepository.SaveChangesAsync();
        }

        public DAL.Product Find(Guid productId)
        {
            return _productRepository.Find(productId);
        }
    }
}

