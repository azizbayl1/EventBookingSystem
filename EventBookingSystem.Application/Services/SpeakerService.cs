using AutoMapper;
using EventBookingSystem.Application.DTOs.Speaker.Request;
using EventBookingSystem.Application.DTOs.Speaker.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Application.Services;

public class SpeakerService : ISpeakerService
{
    private readonly ISpeakerRepository _speakerRepository;
    private readonly IMapper _mapper;

    public SpeakerService(
        ISpeakerRepository speakerRepository,
        IMapper mapper)
    {
        _speakerRepository = speakerRepository;
        _mapper = mapper;
    }
    public void CreateSpeaker(SpeakerRequestDTO speakerRequestDTO)
    {
        var speaker = _mapper.Map<Speaker>(speakerRequestDTO);
        _speakerRepository.Add(speaker);
    }

    public bool DeleteSpeaker(int speakerId)
    {
        var speaker = _speakerRepository.GetById(speakerId);
        if (speaker != null)
        {
            _speakerRepository.Remove(speaker);
            return true;
        }
        return false;
    }

    public SpeakerResponseDTO GetSpeakerByIs(int speakerId)
    {
        var speaker = _speakerRepository.GetById(speakerId);
        return _mapper.Map<SpeakerResponseDTO>(speaker);
    }

    public List<SpeakerResponseDTO> GetSpeakers()
    {
        var speakers = _speakerRepository.GetAll();
        return _mapper.Map<List<SpeakerResponseDTO>>(speakers); 
    }

    public bool UpdateSpeaker(SpeakerRequestDTO speakerRequestDTO)
    {
        var speaker = _speakerRepository.GetById(speakerRequestDTO.Id);
        if (speaker != null)
        {
            var mapped = _mapper.Map<Speaker>(speakerRequestDTO);
            _speakerRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
