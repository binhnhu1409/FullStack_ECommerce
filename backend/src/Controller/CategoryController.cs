namespace backend.src.Controller;

using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController
    : BaseController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
{
    public CategoryController(ICategoryService service) : base(service)
    {
        
    }
}