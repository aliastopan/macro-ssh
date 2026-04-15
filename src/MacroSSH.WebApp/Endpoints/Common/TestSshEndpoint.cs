using Microsoft.AspNetCore.Mvc;
using MacroSSH.Core.Services;
using MacroSSH.WebApp.Interfaces;

namespace MacroSSH.WebApp.Endpoints.Ssh;

public sealed class TestSshEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/ssh/test", TestSsh);
    }

    internal async Task<IResult> TestSsh([FromServices] SshService sshService)
    {
        var result = await sshService.LoginSsh();
        
        return Results.Ok(result);
    }
}