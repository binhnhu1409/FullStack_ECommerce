namespace backend.src.Repositories.UserRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;

public interface IUserRepo : IBaseRepo<User>
{
    Task<User?> GetUserProfileAsync(Guid id);
}
