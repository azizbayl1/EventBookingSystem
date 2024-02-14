namespace EventBookingSystem.Domain.Entities;

public class Speaker : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public virtual ICollection<SpeakerEvent>? SpeakerEvents { get; set; }
}
