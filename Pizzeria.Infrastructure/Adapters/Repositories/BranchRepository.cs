using Microsoft.EntityFrameworkCore;
using Pizzeria.Domain.Entities;
using Pizzeria.Domain.Ports.Repositories;
using Pizzeria.Infrastructure.Configuration.Context;

namespace Pizzeria.Infrastructure.Adapters.Repositories
{
    internal class BranchRepository(PizzeriaDbContext context) : BaseRepository<Branch>(context), IBranchRepository
    {
        public override async Task<Branch?> GetByIdAsync(Guid id)
        {
            return await _context.Branches
                .Where(p => p.Id == id && p.IsActive)
                .Include(p => p.Schedules)
                .FirstOrDefaultAsync();
        }
    }
}
