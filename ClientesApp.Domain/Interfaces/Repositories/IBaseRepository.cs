using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, Tkey> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetManyAsync(Func<TEntity, bool> where);
        Task<List<TEntity>> GetOneAsync(Func<TEntity, bool> where);
        Task<TEntity?> GetByIdAsync(Tkey id);
    }
}
