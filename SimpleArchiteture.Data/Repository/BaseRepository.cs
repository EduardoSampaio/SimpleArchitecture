using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleArchiteture.Data.Interfaces;
using System.Linq.Expressions;

namespace SimpleArchiteture.Data.Repository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> 
        where TEntity : class 
        where TKey : struct
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(TEntity entity)
        {
            EntityEntry entityEntry = _dbContext.Entry(entity);
            entityEntry.State = EntityState.Deleted;
            return Task.CompletedTask;
        }

        public Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = _dbSet.Where(filter);

            _dbSet.RemoveRange(entities);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? top = null, int? skip = null, params string[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties.Length > 0)
            {
                query = includeProperties.Aggregate(query, (theQuery, theInclude) => theQuery.Include(theInclude));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (top.HasValue)
            {
                query = query.Take(top.Value);
            }

            return await query.ToListAsync();
        }

        public Task Update(TEntity entity)
        {
            EntityEntry entityEntry = _dbContext.Entry(entity);
            entityEntry.State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
