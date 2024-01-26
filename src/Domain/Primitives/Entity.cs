namespace Domain.Primitives;

public abstract class Entity(Guid id)
{
    public Guid Id { get; private set; } = id;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public bool IsActive { get; private set; } = true;
    
    public void Delete() =>
        IsActive = false;
}