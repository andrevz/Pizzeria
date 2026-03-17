namespace Pizzeria.WebApi.Endpoints.Branches;

public static class BranchEndpointExtensions
{
    public static IEndpointRouteBuilder MapBranchEndpoints(this IEndpointRouteBuilder app)
    {
        var branchEndpoints = app.MapGroup("api/branches")
                                                .WithDescription("Branch Endpoints");
        
        branchEndpoints.MapCreateBranchEndpoint();
        
        return app;
    }
}