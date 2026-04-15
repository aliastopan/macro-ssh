using MacroSSH.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MacroSSH.Core;

public static class ConfigureService
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<SampleService>();
        services.AddScoped<SshService>();

        return services;
    }
}