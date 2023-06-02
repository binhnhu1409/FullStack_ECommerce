namespace backend.src.Repositories.CategoryRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;
using backend.src.Database;

public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
{
    public CategoryRepo(DatabaseContext context) : base(context)
    {
        
    }
}
