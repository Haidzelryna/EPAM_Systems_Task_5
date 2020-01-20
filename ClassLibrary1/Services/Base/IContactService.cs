using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IContactService : IService
    {
        Task<IEnumerable<DAL.Contact>> GetAllAsync();

        void Add(DAL.Contact Entity);

        void Add(IEnumerable<DAL.Contact> Entities);

        void Remove(DAL.Contact Entity);

        void Remove(IEnumerable<DAL.Contact> Entities);
    }
}
