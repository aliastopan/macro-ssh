using MacroSSH.Core.Repositories;
using MacroSSH.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace MacroSSH.Core;

public static class ConfigureService
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<SampleService>();
        services.AddScoped<SshService>();

        return services;
    }

    public static IServiceCollection AddDapper(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        string connection = configuration.GetConnectionString("Postgres")
            ?? throw new InvalidOperationException("Missing `Postgres` connection string.");

        NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder(connection);

        NpgsqlDataSource dataSource = dataSourceBuilder.Build();
        services.AddSingleton<NpgsqlDataSource>(dataSource);

        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<Repository>();

        return services;
    }
}