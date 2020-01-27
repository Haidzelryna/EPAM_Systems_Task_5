using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();

        T Find(Guid Id);

        Task<T> FindAsync(Guid Id);

        void Add(T entity);

        void Delete(T Entity);

        Task SaveChangesAsync();
    }
}