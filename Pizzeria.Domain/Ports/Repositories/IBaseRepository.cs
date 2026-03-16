using Pizzeria.Domain.Entities;
using System.Linq.Expressions;

namespace Pizzeria.Domain.Ports.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> ListAsync();
        Task<(ICollection<TResult> Collection, int totalCount)> ListAsync<TResult>
        (
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResult>> selector,
            int pageNumber = 1, int pageSize = 10
        );
    }
}
