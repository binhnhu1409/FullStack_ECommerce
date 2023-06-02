namespace backend.src.Services.ProductService;

using backend.src.Services.BaseService;
using backend.src.Models;
using backend.src.DTOs;
using AutoMapper;
using backend.src.Repositories.ProductRepo;

public class ProductService
    : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
{
    public ProductService(IMapper mapper, IProductRepo repository) : base(mapper, repository)
    {
        
    }
}
