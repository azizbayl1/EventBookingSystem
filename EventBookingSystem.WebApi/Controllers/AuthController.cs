using EventBookingSystem.Application.DTOs.Authentication.Request;
using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [Route("/Registration")]
    [HttpPost]
    public IActionResult Registration(RegistrationDTO registrationDTO)
    {
        var message = _authService.Registration(registrationDTO);
        return Ok(message);
    }

    [Route("/Login")]
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromQuery] LoginDTO userLogin)
    {
        var token = _authService.Login(userLogin);
        if(token != null)
        {
            return Ok(token);
        }
        return NotFound("User not found");
    }
}
