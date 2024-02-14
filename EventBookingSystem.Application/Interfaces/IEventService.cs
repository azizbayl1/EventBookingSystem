using EventBookingSystem.Application.DTOs.Event.Request;
using EventBookingSystem.Application.DTOs.Event.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface IEventService
{
    List<EventResponseDTO> GetEvents();
    EventResponseDTO GetEventById(int eventId);  
    void CreateEvent(EventCreateDTO eventCreate);
    bool UpdateEvent(EventUpdateDTO eventUpdate);
    bool DeleteEvent(int eventId);
}
