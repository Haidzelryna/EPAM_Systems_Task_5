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

        //для сопоставления Id - name
        public async Task<IEnumerable<DAL.Sale>> CheckNameId(IEnumerable<DAL.Sale> Entities)
        {
            var _contactRepository = new GenericRepository<DAL.Contact>();

            IEnumerable<DAL.Client> clients = await GetAllAsync();

            foreach (var sale in Entities)
            {
                Guid idClient = new Guid();
                if (clients.Any())
                {
                    var clients1 = clients.Where(c => c.Name == sale.ClientName);
                    var i = clients1.Where(x => x != null).Select(c => c.Id);
                    if (i.Count() > 0)
                    {
                        idClient = i.Where(x => x != null).First();
                    }
                    //создать в БД
                    else
                    {
                        //контакт
                        DAL.Contact contact = new DAL.Contact();
                        contact.Id = Guid.NewGuid();
                        contact.LastName = sale.ClientName;
                        _contactRepository.Add(contact);
                        //SaveChanges();
                        //клиент
                        DAL.Client client = new DAL.Client();
                        client.Id = Guid.NewGuid();
                        client.Name = sale.ClientName;
                        client.ContactId = contact.Id;
                        Add(client);
                        //SaveChanges();
                        idClient = client.Id;

                        clients = await GetAllAsync();
                    }
                }
                //создать в БД
                else
                {
                    //контакт
                    DAL.Contact contact = new DAL.Contact();
                    contact.Id = Guid.NewGuid();
                    contact.LastName = sale.ClientName;
                    _contactRepository.Add(contact);
                    //клиент
                    DAL.Client client = new DAL.Client();
                    client.Id = Guid.NewGuid();
                    client.Name = sale.ClientName;
                    client.ContactId = contact.Id;
                    Add(client);
                    idClient = client.Id;

                    clients = await GetAllAsync();
                }
                sale.ClientId = idClient;
            }

            return Entities;
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
