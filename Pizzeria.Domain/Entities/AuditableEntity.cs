namespace Pizzeria.Domain.Entities;

public class AuditableEntity : BaseEntity
{
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    protected AuditableEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }
}