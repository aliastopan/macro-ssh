namespace MacroSSH.Core.Entities;

public sealed class Macro
{
    public Guid     Id        { get; set; }
    public string   Label     { get; set; } = string.Empty;
    public string   Command   { get; set; } = string.Empty;
    public Guid     CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}