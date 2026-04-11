using System.Reflection;
using MacroSSH.WebApp.Interfaces;

namespace MacroSSH.WebApp.Extensions;

internal static class EndpointExtensions
{
    internal static IServiceCollection AddEndpointDefinitions(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        List<IEndpointDefinition> definitions = [];

        foreach (Assembly assembly in assemblies)
        {
            definitions.AddRange(assembly.ExportedTypes
                .Where(x => typeof(IEndpointDefinition)
                    .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>());
        }

        services.AddSingleton(definitions as IReadOnlyCollection<IEndpointDefinition>);
        return services;
    }

    internal static WebApplication UseEndpointDefinitions(this WebApplication app)
    {
        IReadOnlyCollection<IEndpointDefinition> routeEndpoints = app.Services
            .GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (IEndpointDefinition route in routeEndpoints)
        {
            route.DefineEndpoints(app);
        }

        return app;
    }
}