using EventBookingSystem.Application.DTOs.SpeakerEvent.Request;
using EventBookingSystem.Application.DTOs.SpeakerEvent.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface ISpeakerEventService
{
    List<SpeakerEventResponseDTO> GetSpeakerEvents();
    SpeakerEventResponseDTO GetSpeakerEventById(int id);
    void CreateSpeakerEvent(SpeakerEventRequestDTO speakerEventRequestDTO);
    bool UpdateSpeakerEvent(SpeakerEventRequestDTO speakerEventRequestDTO);   
    bool DeleteSpeakerEvent(int id);
}
