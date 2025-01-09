using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task Delete(int id);
        Task Delete(T entity);
        Task<IReadOnlyList<T>> GetAll();
        Task Update(T entity);
        Task<T> Add(T entity);
        Task<bool> Exist(int id);
    }
}
