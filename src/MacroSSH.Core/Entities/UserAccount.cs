namespace MacroSSH.Core.Entities;

public sealed class UserAccount
{
    public Guid     Id           { get; set; }
    public string   Username     { get; set; } = string.Empty;
    public string   PasswordHash { get; set; } = string.Empty;
    public string   Role         { get; set; } = "teknisi";
    public DateTime CreatedAt    { get; set; }
}