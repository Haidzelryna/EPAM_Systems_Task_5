
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IService<T> : IService
    {
        Task<IEnumerable<T>> GetAllAsync();

        void Add(T Entity);

        void Add(IEnumerable<T> Entities);

        void Remove(T Entity);

        void Remove(IEnumerable<T> Entities);
    }
}
