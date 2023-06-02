namespace backend.src.Services.ProductService;

using backend.src.Services.BaseService;
using backend.src.DTOs;
using backend.src.Models;

public interface IProductService 
    : IBaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
{
    
}
