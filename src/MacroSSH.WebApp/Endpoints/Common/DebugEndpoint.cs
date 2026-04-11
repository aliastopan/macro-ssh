using Microsoft.AspNetCore.Mvc;
using MacroSSH.Core.Services;
using MacroSSH.WebApp.Interfaces;

namespace MacroSSH.WebApp.Endpoints.Common;

public sealed class DebugEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/hello", Debug);
    }

    internal IResult Debug([FromServices] SampleService sampleService)
    {
        var hello =  sampleService.GetHelloWorld();

        return Results.Ok(hello);
    }
}