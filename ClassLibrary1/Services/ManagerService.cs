using System;
using System.Collections.Generic;
using AutoMapper;
using DAL.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Services
{
    public class ManagerService : IService<BLL.Manager>
    {
        private readonly IGenericRepository<DAL.Manager> _managerRepository;
        private readonly IMapper _mapper;

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public ManagerService(IMapper mapper)
        {
            _managerRepository = new GenericRepository<DAL.Manager>();
            _mapper = mapper;
        }

        public ManagerService(IMapper mapper, IGenericRepository<DAL.Manager> managerRepository)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BLL.Manager>> GetAllAsync()
        {
            IEnumerable<DAL.Manager> dalEntities = Enumerable.Empty<DAL.Manager>();
            await _locker.LockAsync(async () =>
            {
                dalEntities = await _managerRepository.GetAllAsync();
            });
            return _mapper.Map<IEnumerable<BLL.Manager>>(dalEntities);
        }

        public async Task<BLL.Manager> FindAsync(Guid managerId)
        {
            DAL.Manager dalEntity = new DAL.Manager();
            await _locker.LockAsync(async () =>
            {
                dalEntity = await _managerRepository.FindAsync(managerId);
            });
            return _mapper.Map<BLL.Manager>(dalEntity);
        }

        public void Remove(BLL.Manager Entity)
        {
            var dalEntity = _mapper.Map<DAL.Manager>(Entity);
            _managerRepository.Delete(dalEntity);
        }

        public void Remove(IEnumerable<BLL.Manager> Entities)
        {
            var dalEntities = _mapper.Map<IEnumerable<DAL.Manager>>(Entities);
            _managerRepository.Delete(dalEntities);
        }

        public void Add(BLL.Manager Entity)
        {
            var dalEntity = _mapper.Map<DAL.Manager>(Entity);
            _managerRepository.Add(dalEntity);
        }

        public void Add(IEnumerable<BLL.Manager> Entities)
        {
            var dalEntities = _mapper.Map<IEnumerable<DAL.Manager>>(Entities);
            _managerRepository.Add(dalEntities);
        }

        public async Task SaveChangesAsync()
        {
            await _managerRepository.SaveChangesAsync();
        }
    }
}
