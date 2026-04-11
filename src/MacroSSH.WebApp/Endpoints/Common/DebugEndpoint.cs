using MacroSSH.WebApp.Interfaces;

namespace MacroSSH.WebApp.Endpoints.Common;

public sealed class DebugEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/hello", Debug);
    }

    internal IResult Debug()
    {
        return Results.Ok("Hello, World!");
    }
}