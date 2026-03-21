using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Contracts.UseCases;
using Pizzeria.Application.DTOs.Request.Branch;
using Pizzeria.Application.DTOs.Response.Branch;

namespace Pizzeria.WebApi.Endpoints.Branches;

public static class CreateBranchEndpoint
{
    public static IEndpointRouteBuilder MapCreateBranchEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", async Task<IResult> ([FromBody] CreateBranchRequest request, [FromServices] BranchUseCases useCases) =>
        {
            var response = await useCases.Create.ExecuteAsync(request);

            if (!response.IsSuccess)
            {
                return TypedResults.BadRequest(response.ErrorMessage);
            }

            return TypedResults.CreatedAtRoute(response.Value, "GetBranch", new { id = response.Value!.Id });
        })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithName("CreateBranch")
        .WithDescription("Creates a new branch");
        
        return app;
    }
}