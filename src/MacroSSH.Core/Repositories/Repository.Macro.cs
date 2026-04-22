using Dapper;
using MacroSSH.Core.Entities;

namespace MacroSSH.Core.Repositories;

public sealed partial class Repository
{
    public async Task<bool> AddMacroAsync(Macro macro)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();

        const string sql = """
            INSERT INTO macro (id, label, command, created_by, created_at)
            VALUES (@Id, @Label, @Command, @CreatedBy, @CreatedAt)
            """;

        var rows = await connection.ExecuteAsync(sql, macro);

        return rows > 0;
    }

    public async Task<bool> DeleteMacroAsync(Guid id)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();

        const string sql = "DELETE FROM macro WHERE id = @Id";

        var rows = await connection.ExecuteAsync(sql, new { Id = id });

        return rows > 0;
    }
}