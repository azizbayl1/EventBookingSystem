namespace EventBookingSystem.Application.DTOs.EventSeat.Response;

public class EventSeatResponseDTO
{
    public int Id { get; set; }
    public int Row { get; set; }
    public int SeatNumber { get; set; }
    public string EventTitle { get; set; } //Name
    public bool IsAvailable { get; set; }
}
