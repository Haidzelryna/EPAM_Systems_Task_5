using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repository;

namespace BLL.Services
{
    public class ClientService : IService<DAL.Client>
    {
        private readonly IGenericRepository<DAL.Client> _clientRepository;
        private readonly IMapper _mapper;

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        static object locker = new object();

        public ClientService(IMapper mapper)
        {
            _clientRepository = new GenericRepository<DAL.Client>();
            _mapper = mapper;
        }

        public ClientService(IMapper mapper, IGenericRepository<DAL.Client> clientRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DAL.Client>> GetAllAsync()
        {
            IEnumerable<DAL.Client> result = Enumerable.Empty<DAL.Client>();
            await _locker.LockAsync(async () =>
            {
                result = await _clientRepository.GetAllAsync();
            });
            return result;
        }

        public async Task<DAL.Client> FindAsync(Guid Id)
        {
            DAL.Client result = new DAL.Client();
            await _locker.LockAsync(async () =>
            {
                result = await _clientRepository.FindAsync(Id);
            });
            return result;
        }

        public async Task<bool> Check(IEnumerable<string> clientsCheck)
        {
            IEnumerable<DAL.Client> clients = await GetAllAsync();
            foreach (string clientName in clientsCheck)
            {
                if (clients.Select(c => c.Name).ToList().Contains(clientName) == false)
                {
                    return false;
                };
            }
            return true;
        }

        public void Remove(DAL.Client Entity)
        {
            _clientRepository.Delete(Entity);
        }

        public void Remove(IEnumerable<DAL.Client> Entities)
        {
            _clientRepository.Delete(Entities);
        }

        public void Add(DAL.Client Entity)
        {
            _clientRepository.Add(Entity);
        }

        public void Add(IEnumerable<DAL.Client> Entities)
        {
            _clientRepository.Add(Entities);
        }

        public async Task SaveChangesAsync()
        {
            await _clientRepository.SaveChangesAsync();
        }

        public DAL.Client Find(Guid clientId)
        {
            return _clientRepository.Find(clientId);
        }
    }
}
