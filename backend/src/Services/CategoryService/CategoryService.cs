namespace backend.src.Services.CategoryService;

using backend.src.Services.BaseService;
using backend.src.Models;
using backend.src.DTOs;
using AutoMapper;
using backend.src.Repositories.CategoryRepo;

public class CategoryService
    : BaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
{
    public CategoryService(IMapper mapper, ICategoryRepo repository) 
        : base(mapper, repository)
    {
        
    }
}
