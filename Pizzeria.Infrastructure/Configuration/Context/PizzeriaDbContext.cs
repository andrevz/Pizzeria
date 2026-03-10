using Microsoft.EntityFrameworkCore;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Configuration.Context;

public class PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : DbContext(options)
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<BranchSchedule> BranchSchedules { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzeriaDbContext).Assembly);
    }
}