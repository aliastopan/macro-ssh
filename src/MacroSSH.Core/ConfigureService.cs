using MacroSSH.Core.Services;
using MacroSSH.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MacroSSH.Core;

public static class ConfigureService
{
    public static IServiceCollection AddCoreServices(
        this IServiceCollection services,
        IConfiguration configuration)          // ← tambah parameter ini
    {
        var connectionString = configuration
            .GetConnectionString("DefaultConnection")!;

        services.AddScoped<SampleService>();
        // services.AddScoped<SshService>();
        // services.AddScoped<SshCommandService>();
        services.AddScoped<IDbRepository>(
            _ => new DbRepository(connectionString)
        );

        return services;
    }
}