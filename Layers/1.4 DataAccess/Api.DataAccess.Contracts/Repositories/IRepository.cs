using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Exists(int id);
        Task<IEnumerable<T>> GetAll();   
        Task<T> Get(int id);
        Task DeleteAsync(int id);
        Task<T> Update(int id, T Element);
        Task<T> Add(T Element);
    }
}