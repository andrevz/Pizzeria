using Pizzeria.Application.Contracts.UseCases;
using Pizzeria.Application.DTOs.Request.Branch;

namespace Pizzeria.WebApi.Endpoints.Branches;

public static class UpdateBranchEndpoint
{
    public static IEndpointRouteBuilder MapUpdateBranchEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("{id:guid}", async (Guid id, UpdateBranchRequest request, BranchUseCases useCases) =>
        {
            var result = await useCases.Update.ExecuteAsync(id, request);
            if (result is { IsSuccess: false, ErrorMessage: "Branch not found" })
            {
                return Results.NotFound(result.ErrorMessage);
            }
            else if (!result.IsSuccess)
            {
                return Results.BadRequest(result.ErrorMessage);
            }

            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("UpdateBranch")
        .WithDescription("Updates an existing branch.");

        return app;
    }
}
