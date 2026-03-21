using Microsoft.AspNetCore.Http.HttpResults;
using Pizzeria.Application.Contracts.UseCases;
using Pizzeria.Application.DTOs.Response.Branch;

namespace Pizzeria.WebApi.Endpoints.Branches;

public static class GetBranchEndpoint
{
    public static IEndpointRouteBuilder MapGetBranchEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("{id:guid}", async Task<IResult> (Guid id, BranchUseCases useCases) =>
         {
             var branch = await useCases.Get.ExecuteAsync(id);

             if (branch is null)
             {
                 return TypedResults.NotFound();
             }

             return TypedResults.Ok(branch);
         })
        .Produces<BranchResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithName("GetBranch")
        .WithDescription("Retrieves a branch by its ID.");

        return app;
    }
}
