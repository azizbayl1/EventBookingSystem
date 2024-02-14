using AutoMapper;
using EventBookingSystem.Application.DTOs.Venue.Request;
using EventBookingSystem.Application.DTOs.Venue.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Application.Services;

public class VenueService : IVenueService
{
    private readonly IVenueRepository _venueRepository;
    private readonly IMapper _mapper;

    public VenueService(
        IVenueRepository venueRepository,
        IMapper mapper)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
    }

    public void CreateVenue(VenueRequestDTO venueDto)
    {
        var venue = _mapper.Map<Venue>(venueDto);
        _venueRepository.Add(venue);
    }
    public bool DeleteVenue(int id)
    {
        var venue = _venueRepository.GetById(id);
        if(venue != null)
        {
            _venueRepository.Remove(venue);
            return true;
        }
        return false;
    }
    public VenueResponseDTO GetVenueById(int id)
    {
        var venue = _venueRepository.GetById(id);
        return _mapper.Map<VenueResponseDTO>(venue);
    }
    public List<VenueResponseDTO> GetVenues()
    {
        var venues = _venueRepository.GetAll();
        return _mapper.Map<List<VenueResponseDTO>>(venues);
    }
    public bool UpdateVenue(VenueRequestDTO venueRequestDTO)
    {
        var venue = _venueRepository.GetById(venueRequestDTO.Id);
        if (venue != null)
        {
            var mapped = _mapper.Map<Venue>(venueRequestDTO);
            _venueRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
