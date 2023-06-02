namespace backend.src.Controller;

using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.ProductService;

public class ProductController
    : BaseController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
{
    public ProductController(IProductService service) : base(service)
    {
        
    }
}
