namespace Origen.Api.Modules.Auth.Entities;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}