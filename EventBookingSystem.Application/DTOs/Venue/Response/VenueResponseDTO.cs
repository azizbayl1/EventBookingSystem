using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingSystem.Application.DTOs.Venue.Response;

public class VenueResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
}
