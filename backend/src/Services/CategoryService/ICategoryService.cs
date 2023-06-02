namespace backend.src.Services.CategoryService;

using backend.src.Services.BaseService;
using backend.src.Models;
using backend.src.DTOs;

public interface ICategoryService 
    : IBaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
{
    
}
