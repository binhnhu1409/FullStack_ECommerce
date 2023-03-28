namespace backend.src.Repositories.CartRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;
using backend.src.Database;

public class CartRepo : BaseRepo<Cart>, ICartRepo
{
    public CartRepo(DatabaseContext context) : base(context)
    {
        
    }
}
