namespace EventBookingSystem.Domain.Entities;

public class EventSeat : BaseEntity
{
    public int Row { get; set; }
    public int SeatNumber { get; set; }
    public bool IsAvailable { get; set; }
    public int EventId { get; set; }
    public int? ParticipantId { get; set; } 
    public virtual Event Event { get; set; }
    public virtual Participant? Participant { get; set; }    
}
