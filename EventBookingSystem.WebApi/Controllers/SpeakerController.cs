using EventBookingSystem.Application.DTOs.Speaker.Request;
using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("Speaker")]
[ApiController]
public class SpeakerController : ControllerBase
{
    private readonly ISpeakerService _speakerService;

    public SpeakerController(ISpeakerService speakerService)
    {
        _speakerService = speakerService;
    }

    //[Authorize(Roles = "Admin")]
    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetSpeakers()
    {
        return Ok(_speakerService.GetSpeakers());
    }

    //[Authorize(Roles = "Admin")]
    [Route("GetById")]
    [HttpGet]
    public IActionResult GetSpeakerByIs(int speakerId)
    {
        return Ok(_speakerService.GetSpeakerByIs(speakerId));
    }

    //[Authorize(Roles = "Admin")]
    [Route("Create")]
    [HttpPost]
    public IActionResult CreateSpeaker(SpeakerRequestDTO speakerRequestDTO)
    {
        _speakerService.CreateSpeaker(speakerRequestDTO);
        return Ok("Successfully created");
    }

    //[Authorize(Roles = "Admin")]
    [Route("Update")]
    [HttpPut]
    public IActionResult UpdateSpeaker(SpeakerRequestDTO speakerRequestDTO)
    {
        if (_speakerService.UpdateSpeaker(speakerRequestDTO))
        {
            return Ok("Successfully updated");
        }
        return BadRequest($"Speaker with ID {speakerRequestDTO.Id} not found.");
    }

    //[Authorize(Roles = "Admin")]
    [Route("Delete")]
    [HttpDelete]
    public IActionResult DeleteSpeaker(int speakerId)
    {
        if (_speakerService.DeleteSpeaker(speakerId))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest($"Speaker with ID {speakerId} not found.");
    }
}
