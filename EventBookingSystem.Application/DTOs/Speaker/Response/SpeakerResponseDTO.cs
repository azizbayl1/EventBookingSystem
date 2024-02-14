using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingSystem.Application.DTOs.Speaker.Response;

public class SpeakerResponseDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}
