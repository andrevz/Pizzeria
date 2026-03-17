using System.Text.Json;
using Pizzeria.Application.Results;

namespace Pizzeria.WebApi.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unhandled exception processing request");
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        var response = env.IsDevelopment()
            ? TypedResult<object>.Failure(exception.Message)
            : TypedResult<object>.Success("Internal Server Error");
        
        var payload = JsonSerializer.Serialize(response, options);
        
        await context.Response.WriteAsync(payload);
    }
}