namespace Origen.Api.Modules.Auth.Bootstrap;

public class AdminBootstrapOptions
{
    public const string SectionName = "Bootstrap";

    public bool Enabled { get; set; }

    public AdminOptions Admin { get; set; } = new();
}