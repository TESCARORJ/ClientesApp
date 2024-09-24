using System.Linq.Expressions;

namespace ClientesApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, Tkey> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity?> GetByIdAsync(Tkey id);
    }
}
