using AutoMapper;
using EventBookingSystem.Application.DTOs.Category.Request;
using EventBookingSystem.Application.DTOs.Category.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public List<CategoryResponseDTO> GetCategories()
    {
        var categories = _categoryRepository.GetAll();
        return _mapper.Map<List<CategoryResponseDTO>>(categories);
    }
    public CategoryResponseDTO GetCategoryById(int categoryId)
    {
        var category = _categoryRepository.GetById(categoryId);
        return _mapper.Map<CategoryResponseDTO>(category);
    }

    public void CreateCategory(CategoryRequestDTO categoryRequestDTO)
    {
        var category = _mapper.Map<Category>(categoryRequestDTO);
        _categoryRepository.Add(category);
    }
    public bool DeleteCategory(int categoryId)
    {
        var category = _categoryRepository.GetById(categoryId);
        if(category != null)
        {
            _categoryRepository.Remove(category);
            return true;
        }
        return false;
    }
    
    public bool UpdateCategory(CategoryRequestDTO categoryRequestDTO)
    {
        var category = _categoryRepository.GetById(categoryRequestDTO.Id);
        if (category != null)
        {
            var mapped = _mapper.Map<Category>(categoryRequestDTO);
            _categoryRepository.Update(mapped);
            return true;
        }
        return false;
    }
}