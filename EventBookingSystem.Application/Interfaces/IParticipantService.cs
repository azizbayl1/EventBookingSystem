using EventBookingSystem.Application.DTOs.Participant.Request;
using EventBookingSystem.Application.DTOs.Participant.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface IParticipantService
{
    List<ParticipantResponseDTO> GetParticipants();
    ParticipantResponseDTO GetParticipantById(int participantId);
    List<ParticipantResponseDTO> GetParticipantsByEvent(int eventId);
    void CreateParticipant(ParticipantRequestDTO participantRequestDTO);
    bool UpdateParticipant(ParticipantRequestDTO participantRequestDTO);
    bool DeleteParticipant(int participantId);  
}
