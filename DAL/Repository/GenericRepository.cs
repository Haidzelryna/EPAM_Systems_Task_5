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
                DbContextExtensions.RefreshAllEntites(_context);
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
                T deleteEntity = Find(entity.Id);
                _context.Set<T>().Remove(deleteEntity);
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

