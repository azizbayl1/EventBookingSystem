using EventBookingSystem.Application.DTOs.Speaker.Request;
using EventBookingSystem.Application.DTOs.Speaker.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface ISpeakerService
{
    List<SpeakerResponseDTO> GetSpeakers();
    SpeakerResponseDTO GetSpeakerByIs(int speakerId);
    void CreateSpeaker(SpeakerRequestDTO speakerRequestDTO);
    bool DeleteSpeaker(int speakerId);
    bool UpdateSpeaker(SpeakerRequestDTO speakerRequestDTO);
}
