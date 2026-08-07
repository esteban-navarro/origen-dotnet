namespace Origen.Api.Modules.Auth.Entities;

public class User : AuditableEntity
{
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public bool Enabled { get; set; } = true;

    public ICollection<UserRole> UserRoles { get; set; } = [];
}