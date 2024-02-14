using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingSystem.Application.DTOs.Participant.Response;

public class ParticipantResponseDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string EventTitle { get; set; }
    public int EventSeatId { get; set; }    
}
