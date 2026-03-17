using Pizzeria.WebApi.Endpoints.Branches;

namespace Pizzeria.WebApi.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapBranchEndpoints();
        
        return app;
    }
}