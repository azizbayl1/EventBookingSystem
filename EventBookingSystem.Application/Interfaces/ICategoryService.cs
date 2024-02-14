using EventBookingSystem.Application.DTOs.Category.Request;
using EventBookingSystem.Application.DTOs.Category.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface ICategoryService
{
    List<CategoryResponseDTO> GetCategories();
    CategoryResponseDTO GetCategoryById(int categoryId);
    void CreateCategory(CategoryRequestDTO categoryRequestDTO);
    bool UpdateCategory(CategoryRequestDTO categoryRequestDTO);
    bool DeleteCategory(int categoryId);
}
