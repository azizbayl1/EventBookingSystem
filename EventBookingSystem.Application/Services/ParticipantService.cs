using AutoMapper;
using EventBookingSystem.Application.DTOs.Participant.Request;
using EventBookingSystem.Application.DTOs.Participant.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Application.Services;

public class ParticipantService : IParticipantService
{
    private readonly IParticipantRepository _participantRepository;
    private readonly IMapper _mapper;

    public ParticipantService(
        IParticipantRepository participantRepository,
        IMapper mapper)
    {
        _participantRepository = participantRepository;
        _mapper = mapper;
    }

   
    public ParticipantResponseDTO GetParticipantById(int participantId)
    {
        return _mapper.Map<ParticipantResponseDTO>(_participantRepository.GetById(participantId));
    }

    public List<ParticipantResponseDTO> GetParticipants()
    {
        return _mapper.Map<List<ParticipantResponseDTO>>(_participantRepository.GetAll());
    }

    public List<ParticipantResponseDTO> GetParticipantsByEvent(int eventId)
    {
        var participants =  _participantRepository.Find(p=> p.EventId == eventId);
        return _mapper.Map<List<ParticipantResponseDTO>>(participants);

    }
    public void CreateParticipant(ParticipantRequestDTO participantRequestDTO)
    {
        var participant = _mapper.Map<Participant>(participantRequestDTO);
        _participantRepository.Add(participant);
    }

    public bool DeleteParticipant(int participantId)
    {
        var participant = _participantRepository.GetById(participantId);
        if (participant != null)
        {
            _participantRepository.Remove(participant);
            return true;
        }
        return false;
    }
    public bool UpdateParticipant(ParticipantRequestDTO participantRequestDTO)
    {
        var participant = _participantRepository.GetById(participantRequestDTO.Id);
        if (participant != null)
        {
            var mapped = _mapper.Map<Participant>(participant);
            _participantRepository.Remove(mapped);
            return true;
        }
        return false;
    }
}
