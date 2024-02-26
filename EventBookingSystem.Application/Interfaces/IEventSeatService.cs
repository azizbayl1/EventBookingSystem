using EventBookingSystem.Application.DTOs.EventSeat.Response;
using EventBookingSystem.Application.DTOs.Participant.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface IEventSeatService
{
    List<EventSeatResponseDTO> GetSeats();
    List<EventSeatResponseDTO> GetSeatsByEventId(int eventId);
    List<ParticipantResponseDTO> GetMyBookings();
    bool BookSeat(int seatId);
    bool CancelBooking(int seatId);
}
