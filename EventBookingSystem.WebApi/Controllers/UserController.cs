using EventBookingSystem.Application.DTOs.Role.Request;
using EventBookingSystem.Application.DTOs.User.Request;
using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("User")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize(Roles = "Admin")]
    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userService.GetUsers());
    }

    [Authorize(Roles = "Admin")]
    [Route("GetById")]
    [HttpGet]
    public IActionResult GetUserById(int id)
    {
        return Ok(_userService.GetUserById(id));
    }

    [Authorize(Roles = "Admin")]
    [Route("Create")]
    [HttpPost]
    public IActionResult Create(UserCreateDTO userCreateDTO)
    {
        _userService.CreateUser(userCreateDTO);
        return Ok("Successfully created");
    }

    [Authorize(Roles = "Admin")]
    [Route("Update")]
    [HttpPut]
    public IActionResult Update(UserUpdateDTO userUpdateDTO)
    {
        if (_userService.UpdateUser(userUpdateDTO))
        {
            return Ok("Successfully updated");
        }
        return BadRequest($"User with ID {userUpdateDTO.Id} not found.");
    }

    [Authorize(Roles = "Admin")]
    [Route("Delete")]
    [HttpDelete]
    public IActionResult DeleteUser(int userId)
    {
        if (_userService.DeleteUser(userId))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest($"User with ID {userId} not found.");
    }

    [Authorize(Roles = "Admin")]
    [Route("AddRole")]
    [HttpPut]
    public IActionResult AddRole([FromQuery] UserRoleDTO userRoleDTO)
    {
        _userService.AddRole(userRoleDTO);
        return Ok();
    }
}
