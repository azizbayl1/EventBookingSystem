using EventBookingSystem.Application.DTOs.Category.Request;
using EventBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.WebApi.Controllers;

[Route("Category")]
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [Authorize(Roles = "Admin, Manager, User")]
    [Route("GetAll")]
    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(_categoryService.GetCategories());
    }


    [Authorize(Roles = "Admin, Manager, User")]
    [Route("GetById")]
    [HttpGet]
    public IActionResult GetCategoryById(int categoryId)
    {
        return Ok(_categoryService.GetCategoryById(categoryId));
    }


    [Authorize(Roles = "Admin, Manager")]
    [Route("Create")]
    [HttpPost]
    public IActionResult CreateCategory(CategoryRequestDTO categoryRequestDTO)
    {
        _categoryService.CreateCategory(categoryRequestDTO);
        return Ok("Successfully created");
    }


    [Authorize(Roles = "Admin, Manager")]
    [Route("Update")]
    [HttpPut]
    public IActionResult UpdateCategory(CategoryRequestDTO categoryRequestDTO)
    {
        if (_categoryService.UpdateCategory(categoryRequestDTO))
        {
            return Ok("Successfully updated");
        }
        return BadRequest($"Category with ID {categoryRequestDTO.Id} not found.");
    }


    [Authorize(Roles = "Admin, Manager")]
    [Route("Delete")]
    [HttpDelete]
    public IActionResult DeleteCategory(int categoryId)
    {
        if (_categoryService.DeleteCategory(categoryId))
        {
            return Ok("Successfully deleted");
        }
        return BadRequest($"Category with ID {categoryId} not found.");
    }
}
