using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Contracts.UseCases;
using Pizzeria.Application.DTOs.Request.Branch;

namespace Pizzeria.WebApi.Endpoints.Branches;

public static class CreateBranchEndpoint
{
    public static IEndpointRouteBuilder MapCreateBranchEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", async ([FromBody] CreateBranchRequest request, [FromServices] BranchUseCases useCases) =>
        {
            var response = await useCases.Create.ExecuteAsync(request);
            
            return TypedResults.CreatedAtRoute(response, "/", new { response.Value?.Id });
        })
        .WithDescription("Create a new branch")
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError);
        
        return app;
    }
}