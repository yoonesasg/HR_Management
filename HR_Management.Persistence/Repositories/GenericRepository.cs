using HR_Management.Application.Persistence.Contracts;
using HR_Management.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HR_ManagementDbContext _context;
        public GenericRepository(HR_ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
