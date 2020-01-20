using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using BLL.Services.Base;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class ContactService : IContactService
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

        public async Task<IEnumerable<DAL.Contact>> GetAllAsync()
        {
            IEnumerable<DAL.Contact> result = Enumerable.Empty<DAL.Contact>();
            await _locker.LockAsync(async () =>
            {
                result = await _contactRepository.GetAllAsync();
            });
            return result;
        }

        public void Remove(DAL.Contact Entity)
        {
            _contactRepository.Delete(Entity);
        }

        public void Remove(IEnumerable<DAL.Contact> Entities)
        {
            _contactRepository.Delete(Entities);
        }

        public void Add(DAL.Contact Entity)
        {
            _contactRepository.Add(Entity);
            SaveChanges();
        }

        public void Add(IEnumerable<DAL.Contact> Entities)
        {
            _contactRepository.Add(Entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _contactRepository.SaveChanges();
        }
    }
}

