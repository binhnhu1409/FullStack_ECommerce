namespace backend.src.Repositories.ImageRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;

public interface IImageRepo : IBaseRepo<Image>
{
    // Task<IEnumerable<Image>> GetImagesByProductIdAsync(string productId);
}
