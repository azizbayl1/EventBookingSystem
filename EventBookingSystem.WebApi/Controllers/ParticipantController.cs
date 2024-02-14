using EventBookingSystem.Application.DTOs.Participant.Request;
using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("Participant")]
[ApiController]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _participantService;

    public ParticipantController(
        IParticipantService participantService)
    {
        _participantService = participantService;
    }

    //[Authorize(Roles = "Admin, Manager")]
    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetParticipants()
    {
        return Ok(_participantService.GetParticipants());
    }

    [Authorize(Roles = "Admin")]
    [Route("GetById")]
    [HttpGet]
    public IActionResult GetParticipantById(int participantId)
    {
        return Ok(_participantService.GetParticipantById(participantId));
    }

    [Authorize(Roles = "Admin")]
    [Route("GetByEvent")]
    [HttpGet]
    public IActionResult GetParticipantsByEvent(int eventId)
    {
        return Ok(_participantService.GetParticipantsByEvent(eventId));
    }

    [Authorize(Roles = "Admin")]
    [Route("Create")]
    [HttpPost]
    public IActionResult CreateParticipant(ParticipantRequestDTO participantRequestDTO)
    {
        _participantService.CreateParticipant(participantRequestDTO);
        return Ok("Successfully created");
    }

    [Authorize(Roles = "Admin")]
    [Route("Update")]
    [HttpPut]
    public IActionResult UpdateParticipant(ParticipantRequestDTO participantRequestDTO)
    {
        if (_participantService.UpdateParticipant(participantRequestDTO))
        {
            return Ok("Successfully updated");
        }
        return BadRequest($"Oarticipant with ID {participantRequestDTO.Id} not found.");
    }

    [Authorize(Roles = "Admin")]
    [Route("Delete")]
    [HttpDelete]
    public IActionResult DeleteParticipant(int participantId)
    {
        if (_participantService.DeleteParticipant(participantId))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest($"Participant with ID {participantId} not found.");
    }
}
