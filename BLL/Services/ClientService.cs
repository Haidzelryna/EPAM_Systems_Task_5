using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repository;

namespace BLL.Services
{
    public class ClientService : IService<BLL.Client>
    {
        private readonly IGenericRepository<DAL.Client> _clientRepository;
        private readonly IMapper _mapper;

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        static object locker = new object();

        public ClientService(IMapper mapper)
        {

        }

        public ClientService(IMapper mapper, IGenericRepository<DAL.Client> clientRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BLL.Client>> GetAllAsync()
        {
            IEnumerable<DAL.Client> dalEntities = Enumerable.Empty<DAL.Client>();
            await _locker.LockAsync(async () =>
            {
                dalEntities = await _clientRepository.GetAllAsync();
            });
            return _mapper.Map<IEnumerable<BLL.Client>>(dalEntities);
        }

        public async Task<BLL.Client> FindAsync(Guid Id)
        {
            DAL.Client dalEntity = new DAL.Client();
            await _locker.LockAsync(async () =>
            {
                dalEntity = await _clientRepository.FindAsync(Id);
            });
            return _mapper.Map<BLL.Client>(dalEntity);
        }

        public void Add(BLL.Client Entity)
        {
            var dalEntity = _mapper.Map<DAL.Client>(Entity);
            _clientRepository.Add(dalEntity);
        }

        public void Remove(BLL.Client Entity)
        {
            var dalEntity = _mapper.Map<DAL.Client>(Entity);
            _clientRepository.Delete(dalEntity);
        }

        public async Task SaveChangesAsync()
        {
            await _clientRepository.SaveChangesAsync();
        }

        public async void Update(Client Entity)
        {
            var dalEntity = _mapper.Map<DAL.Client>(Entity);
            var dalEntityFind = await _clientRepository.FindAsync(Entity.Id);
            Copy(dalEntityFind, dalEntity);
        }

        public void Copy(DAL.Client target, DAL.Client source)
        {
            target.Name = source.Name;
            target.ContactId = source.ContactId;
        }
    }
}
