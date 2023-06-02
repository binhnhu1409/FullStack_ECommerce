namespace backend.src.Repositories.ProductRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;
using backend.src.Database;

public class ProductRepo : BaseRepo<Product>, IProductRepo
{
    public ProductRepo(DatabaseContext context) : base(context)
    {
        
    }
}
