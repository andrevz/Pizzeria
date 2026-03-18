using Microsoft.AspNetCore.Http.HttpResults;
using Pizzeria.Application.Contracts.UseCases;

namespace Pizzeria.WebApi.Endpoints.Branches;

public static class DeleteBranchEndpoint
{
    public static IEndpointRouteBuilder MapDeleteBranchEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id:guid}", async Task<Results<NoContent, NotFound>> (Guid id, BranchUseCases useCases) =>
        {
            var result = await useCases.Delete.ExecuteAsync(id);
            if (result.Value is null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithName("DeleteBranch")
        .WithDescription("Deletes a branch by its ID.");

        return app;
    }
}
