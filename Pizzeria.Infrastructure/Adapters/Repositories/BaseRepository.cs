using Microsoft.EntityFrameworkCore;
using Pizzeria.Domain.Entities;
using Pizzeria.Domain.Ports.Repositories;
using Pizzeria.Infrastructure.Configuration.Context;
using System.Linq.Expressions;

namespace Pizzeria.Infrastructure.Adapters.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PizzeriaDbContext _context;

        public BaseRepository(PizzeriaDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> AddAsync(TEntity entity)
        {
            var response = await _context.Set<TEntity>().AddAsync(entity);

            return response.Entity;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<ICollection<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(ICollection<TResult> Collection, int totalCount)> ListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, int pageNumber = 1, int pageSize = 10)
        {
            var response = await _context.Set<TEntity>()
                .Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(selector)
                .ToListAsync();

            var total = await _context.Set<TEntity>()
                .Where(predicate)
                .CountAsync();

            return (response, total);
        }

        public TEntity Update(TEntity entity)
        {
            var response = _context.Set<TEntity>().Update(entity);

            return response.Entity;
        }
    }
}
