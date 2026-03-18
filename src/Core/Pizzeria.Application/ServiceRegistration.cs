using Microsoft.Extensions.DependencyInjection;
using Pizzeria.Application.Contracts.UseCases;
using Pizzeria.Application.Ports.BranchUseCases;
using Pizzeria.Application.UseCases.BranchUseCases;

namespace Pizzeria.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateBranchUseCase, CreateBranchUseCase>();
        services.AddScoped<IDeleteBranchUseCase, DeleteBranchUseCase>();
        services.AddScoped<IGetAllBranchUseCase, GetAllBranchUseCase>();
        services.AddScoped<IGetBranchUseCase, GetBranchUseCase>();
        services.AddScoped<IUpdateBranchUseCase, UpdateBranchUseCase>();

        services.AddScoped<BranchUseCases>();

        return services;
    }
}
