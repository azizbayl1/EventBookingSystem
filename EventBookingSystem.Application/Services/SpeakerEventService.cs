using AutoMapper;
using EventBookingSystem.Application.DTOs.SpeakerEvent.Request;
using EventBookingSystem.Application.DTOs.SpeakerEvent.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Application.Services;

public class SpeakerEventService : ISpeakerEventService
{
    private readonly ISpeakerEventRepository _speakerEventRepository;
    private readonly IMapper _mapper;

    public SpeakerEventService(
        ISpeakerEventRepository speakerEventRepository,
        IMapper mapper)
    {
        _speakerEventRepository = speakerEventRepository;
        _mapper = mapper;
    }
    public List<SpeakerEventResponseDTO> GetSpeakerEvents()
    {
        return _mapper.Map<List<SpeakerEventResponseDTO>>(_speakerEventRepository.GetAll());
    }

    public SpeakerEventResponseDTO GetSpeakerEventById(int id)
    {
        var speakerEvent = _speakerEventRepository.GetById(id);
        return _mapper.Map<SpeakerEventResponseDTO>(speakerEvent);
    }

    public void CreateSpeakerEvent(SpeakerEventRequestDTO speakerEventRequestDTO)
    {
        var speakerEvent = _mapper.Map<SpeakerEvent>(speakerEventRequestDTO);
        _speakerEventRepository.Add(speakerEvent);
    }

    public bool DeleteSpeakerEvent(int id)
    {
        var speakerEvent = _speakerEventRepository.GetById(id);
        if (speakerEvent != null)
        {
            _speakerEventRepository.Remove(speakerEvent);
            return true;
        }
        return false;
    }

    public bool UpdateSpeakerEvent(SpeakerEventRequestDTO speakerEventRequestDTO)
    {
        var speakerEvent = _speakerEventRepository.GetById(speakerEventRequestDTO.Id);
        if (speakerEvent != null)
        {
            var mapped = _mapper.Map<SpeakerEvent>(speakerEventRequestDTO);
            _speakerEventRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
