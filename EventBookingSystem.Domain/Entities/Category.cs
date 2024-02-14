namespace EventBookingSystem.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public virtual ICollection<Event> Events { get; set; }
}
