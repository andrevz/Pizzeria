using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizzeria.Domain.Ports.Repositories;
using Pizzeria.Domain.Ports.Services;
using Pizzeria.Infrastructure.Adapters.Repositories;
using Pizzeria.Infrastructure.Configuration.Context;
using Pizzeria.Infrastructure.Services;

namespace Pizzeria.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PizzeriaDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PizzeriaDb"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBranchRepository, BranchRepository>();

        return services;
    }
}
