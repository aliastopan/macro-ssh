using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace MacroSSH.Core.Repositories;

public sealed partial class Repository
{
    private readonly ILogger<Repository> _logger;
    private readonly NpgsqlDataSource _dataSource;

    public Repository( ILogger<Repository> logger,
        NpgsqlDataSource dataSource)
    {
        _logger = logger;
        _dataSource = dataSource;
    }

    public async Task<bool> TestConnectionAsync()
    {
        try
        {
            await using NpgsqlConnection connection = await _dataSource.OpenConnectionAsync();

            const string sql = "SELECT 1";
            await connection.ExecuteScalarAsync<int>(sql);

            return true;
        }
        catch
        {
            return false;
        }
    }
}