using Dapper;
using MacroSSH.Core.Entities;

namespace MacroSSH.Core.Repositories;

public sealed partial class Repository
{
    public async Task<bool> AddUserAccountAsync(UserAccount user)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();

        const string sql = """
            INSERT INTO user_account (id, username, password_hash, role, created_at)
            VALUES (@Id, @Username, @PasswordHash, @Role, @CreatedAt)
            """;

        var rows = await connection.ExecuteAsync(sql, user);

        return rows > 0;
    }

    public async Task<bool> EditUserAccountAsync(UserAccount user)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();

        const string sql = """
            UPDATE user_account
            SET username      = @Username,
                password_hash = @PasswordHash,
                role          = @Role
            WHERE id = @Id
            """;

        var rows = await connection.ExecuteAsync(sql, user);

        return rows > 0;
    }
}