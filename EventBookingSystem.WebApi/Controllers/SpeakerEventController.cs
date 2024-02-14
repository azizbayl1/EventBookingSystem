using EventBookingSystem.Application.DTOs.SpeakerEvent.Request;
using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("SpeakerEvent")]
[ApiController]
public class SpeakerEventController : ControllerBase
{
    private readonly ISpeakerEventService _speakerEventService;

    public SpeakerEventController(ISpeakerEventService speakerEventService)
    {
        _speakerEventService = speakerEventService;
    }

    //[Authorize(Roles = "Admin")]
    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetSpeakerEvents()
    {
        return Ok(_speakerEventService.GetSpeakerEvents());
    }

    //[Authorize(Roles = "Admin")]
    [Route("GetById")]
    [HttpGet]
    public IActionResult GetSpeakerEventById(int speakerEventId)
    {
        return Ok(_speakerEventService.GetSpeakerEventById(speakerEventId));
    }

    //[Authorize(Roles = "Admin")]
    [Route("Create")]
    [HttpPost]
    public IActionResult CreateSpeakerEvent(SpeakerEventRequestDTO speakerEventRequestDTO)
    {
        _speakerEventService.CreateSpeakerEvent(speakerEventRequestDTO);
        return Ok("Successfully created");
    }

    //[Authorize(Roles = "Admin")]
    [Route("Update")]
    [HttpPut]
    public IActionResult UpdateSpeakerEvent(SpeakerEventRequestDTO speakerEventRequestDTO)
    {
        if (_speakerEventService.UpdateSpeakerEvent(speakerEventRequestDTO))
        {
            return Ok("Successfully updated");
        }
        return BadRequest($"SpeakerEvent with ID {speakerEventRequestDTO.Id} not found.");
    }

    //[Authorize(Roles = "Admin")]
    [Route("Delete")]
    [HttpDelete]
    public IActionResult DeleteSpeakerEvent(int speakerEventId)
    {
        if (_speakerEventService.DeleteSpeakerEvent(speakerEventId))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest($"SpeakerEvent with ID {speakerEventId} not found.");
    }
}
