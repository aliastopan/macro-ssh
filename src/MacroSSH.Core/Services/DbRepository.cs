using Dapper;
using Npgsql;

namespace MacroSSH.Core.Repositories;

public sealed class DbRepository : IDbRepository
{
    private readonly string _connectionString;

    public DbRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<string> TestConnection()
    {
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);

            await connection.OpenAsync();

            var result = await connection.QuerySingleAsync<string>(
                "SELECT 'PostgreSQL connected: ' || version()"
            );

            return result;
        }
        catch (Exception ex)
        {
            return $"ERROR: {ex.Message}";
        }
    }
}