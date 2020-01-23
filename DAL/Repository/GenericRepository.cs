using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private SalesEntities _context;

        static object locker = new object();

        public GenericRepository()
        {
            if (_context == null)
                _context = new SalesEntities();
        }

        public GenericRepository(SalesEntities salesDbContext)
        {
            _context = salesDbContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
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

        public void Add(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public void Delete(T entity)
        {
            try
            {
                if (!_context.Set<T>().Local.Contains(entity))
                {
                    _context.Set<T>().Attach(entity);
                }
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public void Delete(IEnumerable<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}

