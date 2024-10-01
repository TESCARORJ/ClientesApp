using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Infra.Data.SqlServer.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClientesApp.Infra.Data.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DataContext _dataContext;

        protected BaseRepository(DataContext context)
        {
            _dataContext = context;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dataContext.Set<TEntity>().Where(where).ToListAsync();
        }

        public virtual async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dataContext.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }


        public virtual async Task<bool> VerifyExistsAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dataContext.Set<TEntity>().AnyAsync(where);
        }


        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
