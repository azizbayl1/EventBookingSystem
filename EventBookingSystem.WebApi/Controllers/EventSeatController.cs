using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("EventSeat")]
[ApiController]
public class EventSeatController : ControllerBase
{
    private readonly IEventSeatService _eventSeatService;

    public EventSeatController(IEventSeatService eventSeatService)
    {
        _eventSeatService = eventSeatService;
    }

    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetSeats()
    {
        return Ok(_eventSeatService.GetSeats());
    }

    [Route("GetSeatsByEventId")]
    [HttpGet]
    public IActionResult GetSeatsByEvent(int eventId) 
    {
        return Ok(_eventSeatService.GetSeatsByEventId(eventId));
    }

    [Route("BookSeat")]
    [HttpPut]
    public IActionResult BookSeat(int seatId)
    {
        if (_eventSeatService.BookSeat(seatId))
        {
            return Ok("Seat booked successfully");
        }
        return BadRequest("Seat is not available");
    }

    [Route("CancelBooking")]
    [HttpPut]
    public IActionResult CancelBooking(int seatId)
    {
        if (_eventSeatService.CancelBooking(seatId))
        {
            return Ok("Seat canceled successfully");
        }
        return BadRequest("Seat is not booked");
    }

    [Route("GetMyBookings")]
    [HttpGet]
    public IActionResult GetMyBookings()
    {
        return Ok(_eventSeatService.GetMyBookings());
    }
}
