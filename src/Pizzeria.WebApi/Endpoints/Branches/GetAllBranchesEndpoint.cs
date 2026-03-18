using Pizzeria.Application.Contracts.UseCases;

namespace Pizzeria.WebApi.Endpoints.Branches;

public static class GetAllBranchesEndpoint
{
    public static IEndpointRouteBuilder MapGetAllBranchesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (BranchUseCases useCases) =>
        {
            var branches = await useCases.GetAll.ExecuteAsync();
            return Results.Ok(branches);
        })
        .Produces(StatusCodes.Status200OK)
        .WithName("GetAllBranches")
        .WithDescription("Retrieves a list of all branches.");

        return app;
    }
}
