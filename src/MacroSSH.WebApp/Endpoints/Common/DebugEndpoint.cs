using Microsoft.AspNetCore.Mvc;
using MacroSSH.Core.Services;
using MacroSSH.WebApp.Interfaces;
using MacroSSH.Core.Repositories;

namespace MacroSSH.WebApp.Endpoints.Common;

public sealed class DebugEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/hello", Debug);
        app.MapGet("/api/test/psql", PsqlTest);
    }

    internal IResult Debug([FromServices] SampleService sampleService)
    {
        var hello =  sampleService.GetHelloWorld();

        return Results.Ok(hello);
    }

    internal async Task<IResult> PsqlTest([FromServices] Repository repository)
    {
        bool isConnected =  await repository.TestConnectionAsync();

        string result = isConnected
            ? "PSQL CONNECTED."
            : "PSQL NOT CONNECTED.";

        return Results.Ok(result);
    }
}