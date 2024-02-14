namespace EventBookingSystem.Domain.Entities;

public class SpeakerEvent : BaseEntity
{
    public int SpeakerId { get; set; }
    public int EventId { get; set; }
    public virtual Event Event { get; set; }
    public virtual Speaker Speaker { get; set; }
}
