using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int type);
        Task<T> Create(T type);
        Task<T> Update(T type);
        Task Remove(T type);
    }
}