using Dapper;
using MacroSSH.Core.Entities;

namespace MacroSSH.Core.Repositories;

public sealed partial class Repository
{
    public async Task<bool> AddMacroAsync(Macro macro)
    {
        await using var connection = await _dataSource.OpenConnectionAsync();

        const string sql = """
            INSERT INTO macro (
                id, name, description, button_name,
                jumphost, jump_port,
                olt_name, olt_username, olt_pass_encrypted, vendor,
                command, extra_steps,
                is_active, expires_at, created_by, created_at, updated_at)
            VALUES (
                @Id, @Name, @Description, @ButtonName,
                @JumpHost, @JumpPort,
                @OltName, @OltUsername, @OltPassEncrypted, @Vendor,
                @Command, @ExtraSteps,
                @IsActive, @ExpiresAt, @CreatedBy, @CreatedAt, @UpdatedAt)
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