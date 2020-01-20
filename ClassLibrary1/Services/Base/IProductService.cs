using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IProductService : IService
    {
        Task<IEnumerable<DAL.Product>> GetAllAsync();

        void Add(DAL.Product Entity);

        void Add(IEnumerable<DAL.Product> Entities);

        void Remove(DAL.Product Entity);

        void Remove(IEnumerable<DAL.Product> Entities);
    }
}
