namespace backend.src.Repositories.CartRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;

public interface ICartRepo : IBaseRepo<Cart>
{
    // Task<bool> AddProductToCartAsync(string userId, string productId, int quantity);
    // Task<bool> RemoveProductFromCartAsync(string userId, string productId, int quantity);
    // Task<bool> ClearCartAsync(string cartId);
}
