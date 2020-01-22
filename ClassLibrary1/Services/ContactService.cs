using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class ContactService : IService<BLL.Contact>
    {
        private readonly IGenericRepository<DAL.Contact> _contactRepository;
        private readonly IMapper _mapper;

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public ContactService(IMapper mapper)
        {
            _contactRepository = new GenericRepository<DAL.Contact>();
            _mapper = mapper;
        }

        public ContactService(IMapper mapper, IGenericRepository<DAL.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BLL.Contact>> GetAllAsync()
        {
            IEnumerable<DAL.Contact> dalEntities = Enumerable.Empty<DAL.Contact>();
            await _locker.LockAsync(async () =>
            {
                dalEntities = await _contactRepository.GetAllAsync();
            });
            return _mapper.Map<IEnumerable<BLL.Contact>>(dalEntities);
        }

        public async Task<BLL.Contact> FindAsync(Guid Id)
        {
            DAL.Contact dalEntity = new DAL.Contact();
            await _locker.LockAsync(async () =>
            {
                dalEntity = await _contactRepository.FindAsync(Id);
            });
            return _mapper.Map<BLL.Contact>(dalEntity);
        }

        public void Add(BLL.Contact Entity)
        {
            var dalEntity = _mapper.Map<DAL.Contact>(Entity);
            _contactRepository.Add(dalEntity);
        }

        public void Add(IEnumerable<BLL.Contact> Entities)
        {
            var dalEntities = _mapper.Map<IEnumerable<DAL.Contact>>(Entities);
            _contactRepository.Add(dalEntities);
        }

        public void Remove(BLL.Contact Entity)
        {
            var dalEntity = _mapper.Map<DAL.Contact>(Entity);
            _contactRepository.Delete(dalEntity);
        }

        public void Remove(IEnumerable<BLL.Contact> Entities)
        {
            var dalEntities = _mapper.Map<IEnumerable<DAL.Contact>>(Entities);
            _contactRepository.Delete(dalEntities);
        }

        public async Task SaveChangesAsync()
        {
            await _contactRepository.SaveChangesAsync();
        }
    }
}

