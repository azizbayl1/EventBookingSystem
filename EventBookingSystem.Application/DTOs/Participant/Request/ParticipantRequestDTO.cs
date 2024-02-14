using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingSystem.Application.DTOs.Participant.Request;

public class ParticipantRequestDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public int EventSeatId { get; set; }
}
