namespace backend.src.Repositories.ProductRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;

public interface IProductRepo : IBaseRepo<Product>
{
    //Task<Product?> GetProductsByCategoryIdAsync(string categoryId);
}