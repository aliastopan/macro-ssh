namespace MacroSSH.Core.Entities;

public sealed class Macro
{
    public Guid      Id                { get; set; }
    public string    Name              { get; set; } = string.Empty;
    public string?   Description       { get; set; }
    public string    ButtonName        { get; set; } = string.Empty;
    public string    JumpHost          { get; set; } = string.Empty;
    public int       JumpPort          { get; set; } = 21112;
    public string    OltName           { get; set; } = string.Empty;
    public string    OltUsername       { get; set; } = string.Empty;
    public string    OltPassEncrypted  { get; set; } = string.Empty;
    public string?   Vendor            { get; set; }
    public string    Command           { get; set; } = string.Empty;
    public string?   ExtraSteps        { get; set; }
    public bool      IsActive          { get; set; } = true;
    public DateTime? ExpiresAt         { get; set; }
    public Guid?     CreatedBy         { get; set; }
    public DateTime  CreatedAt         { get; set; }
    public DateTime  UpdatedAt         { get; set; }
}