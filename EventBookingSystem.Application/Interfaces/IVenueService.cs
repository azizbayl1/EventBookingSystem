using EventBookingSystem.Application.DTOs.Venue.Request;
using EventBookingSystem.Application.DTOs.Venue.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface IVenueService
{
    VenueResponseDTO GetVenueById(int id);
    List<VenueResponseDTO> GetVenues();
    void CreateVenue(VenueRequestDTO venueDto);
    bool DeleteVenue(int id);
    bool UpdateVenue(VenueRequestDTO venueRequestDTO);
}
