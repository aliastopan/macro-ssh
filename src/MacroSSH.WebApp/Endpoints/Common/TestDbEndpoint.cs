using Microsoft.AspNetCore.Mvc;
using MacroSSH.Core.Repositories;
using MacroSSH.WebApp.Interfaces;

namespace MacroSSH.WebApp.Endpoints.Db;

public sealed class TestDbEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/db/test", TestDb);
    }

    internal async Task<IResult> TestDb([FromServices] IDbRepository dbRepository)
    {
        var result = await dbRepository.TestConnection();

        Console.WriteLine(result); //debug

        return Results.Ok(result);
    }
}