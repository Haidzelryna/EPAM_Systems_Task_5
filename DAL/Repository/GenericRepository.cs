using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private static SalesEntities _context;

        static object locker = new object();

        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public GenericRepository()
        {
            //if (_context == null)
            //    _context = new SalesEntities();
        }

        public GenericRepository(SalesEntities salesDbContext)
        {
            _context = salesDbContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            DbContextExtensions.RefreshEntites<T>(_context);
            return await _context.Set<T>().ToListAsync();
        }

        public T Find(Guid Id)
        {
            lock (locker)
            {
                return _context.Set<T>().Find(Id);
            }
        }

        public async Task<T> FindAsync(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            T deleteEntity = Find(entity.Id);
            _context.Set<T>().Remove(deleteEntity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();          
        }
    }
}

