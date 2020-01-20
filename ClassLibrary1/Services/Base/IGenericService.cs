
using System.Collections.Generic;

namespace BLL.Services.Base
{
    public interface IService<T> : IService
    {
        //Task<IEnumerable<DAL.Product>> GetAllAsync();

        void Add(T Entity);

        void Add(IEnumerable<T> Entities);

        void Remove(T Entity);

        void Remove(IEnumerable<T> Entities);
    }
}
