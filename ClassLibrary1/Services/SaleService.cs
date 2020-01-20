using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using BLL.Services.Base;

namespace BLL.Services
{
    public class SaleService : IService<DAL.Sale>
    {
        private readonly IGenericRepository<DAL.Sale> _saleRepository;
        private readonly IMapper _mapper;

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

        public void Add(DAL.Sale Entity)
        {
            _saleRepository.Add(Entity);
            SaveChanges();
        }

        public void Add(IEnumerable<DAL.Sale> Entities)
        {
            _saleRepository.Add(Entities);
            SaveChanges();
        }

        public void Remove(DAL.Sale Entity)
        {
            _saleRepository.Delete(Entity);
        }

        public void Remove(IEnumerable<DAL.Sale> Entities)
        {
            _saleRepository.Delete(Entities);
        }

        public void SaveChanges()
        {
            _saleRepository.SaveChanges();
        }
    }
}

