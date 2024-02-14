namespace EventBookingSystem.Application.DTOs.Event.Response;

public class EventResponseDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string VenueName { get; set; }
    public string CategoryName { get; set; }
}
