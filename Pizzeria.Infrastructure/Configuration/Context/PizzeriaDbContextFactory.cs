using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pizzeria.Infrastructure.Configuration.Context;

public class PizzeriaDbContextFactory : IDesignTimeDbContextFactory<PizzeriaDbContext>
{
    public PizzeriaDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("pizzeria_db") ?? "";

        var optionsBuilder = new DbContextOptionsBuilder<PizzeriaDbContext>();
        optionsBuilder.UseNpgsql(connectionString, options =>
        {
            options.MigrationsHistoryTable("__EFMigrationsHistory");
        });
        
        return new PizzeriaDbContext(optionsBuilder.Options);
    }
}