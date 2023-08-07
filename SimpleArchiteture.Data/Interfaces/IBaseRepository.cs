using System.Linq.Expressions;

namespace SimpleArchiteture.Data.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> 
        where TEntity : class 
        where  TKey : struct
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter = null,
                                          Func<IQueryable<TEntity>, 
                                          IOrderedQueryable<TEntity>> orderBy = null,
                                          int? top = null,
                                          int? skip = null,
                                          params string[] includeProperties);
    }
}
