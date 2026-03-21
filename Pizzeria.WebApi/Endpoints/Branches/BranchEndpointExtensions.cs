namespace Pizzeria.WebApi.Endpoints.Branches;

public static class BranchEndpointExtensions
{
    public static IEndpointRouteBuilder MapBranchEndpoints(this IEndpointRouteBuilder app)
    {
        var branchEndpoints = app.MapGroup("api/branches")
                                 .WithTags("Branches");
        
        branchEndpoints.MapCreateBranchEndpoint();
        branchEndpoints.MapDeleteBranchEndpoint();
        branchEndpoints.MapGetAllBranchesEndpoint();
        branchEndpoints.MapGetBranchEndpoint();
        branchEndpoints.MapUpdateBranchEndpoint();
        
        return app;
    }
}