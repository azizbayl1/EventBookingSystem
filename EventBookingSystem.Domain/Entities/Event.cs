namespace EventBookingSystem.Domain.Entities;

public class Event : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int VenueId { get; set; }
    public int CategoryId { get; set; }



    #region Navigation Properties
    public virtual Venue Venue { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<EventSeat> EventSeats { get; set; }
    public virtual ICollection<Participant> Participants { get; set; }
    public virtual ICollection<SpeakerEvent>? SpeakerEvents { get; set; }

    //public virtual ICollection<EventEvaluation> EventEvaluations { get; set; }
    #endregion
}
