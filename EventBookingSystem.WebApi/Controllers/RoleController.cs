using EventBookingSystem.Application.DTOs.Role.Request;
using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("Role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [Authorize(Roles = "Admin")]
    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetRoles()
    {
        return Ok(_roleService.GetRoles());
    }

    [Authorize(Roles = "Admin")]
    [Route("GetById")]
    [HttpGet]
    public IActionResult GetRoleById(int roleId)
    {
        return Ok(_roleService.GetRoleById(roleId));
    }

    [Authorize(Roles = "Admin")]
    [Route("Create")]
    [HttpPost]
    public IActionResult CreateRole(RoleRequestDTO roleRequestDTO)
    {
        _roleService.CreateRole(roleRequestDTO);
        return Ok("Successfully created");
    }

    [Authorize(Roles = "Admin")]
    [Route("Update")]
    [HttpPut]
    public IActionResult UpdateRole(RoleRequestDTO roleRequestDTO)
    {
        if (_roleService.UpdateRole(roleRequestDTO))
        {
            return Ok("Successfully updated");
        }
        return BadRequest($"Role with ID {roleRequestDTO.Id} not found.");
    }

    [Authorize(Roles = "Admin")]
    [Route("Delete")]
    [HttpDelete]
    public IActionResult DeleteRole(int roleId)
    {
        if (_roleService.DeleteRole(roleId))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest($"Role with ID {roleId} not found.");
    }
}
