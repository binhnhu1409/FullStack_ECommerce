namespace backend.src.Repositories.ImageRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;
using backend.src.Database;

public class ImageRepo : BaseRepo<Image>, IImageRepo
{
    public ImageRepo(DatabaseContext context) : base(context)
    {
        
    }
}
