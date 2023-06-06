namespace backend.src.Repositories.UserRepo;

using backend.src.Repositories.BaseRepo;
using backend.src.Models;
using backend.src.Database;

public class UserRepo : BaseRepo<User>, IUserRepo
{
    public UserRepo(DatabaseContext context) : base(context)
    {

    }

    public async Task<User?> GetUserProfileAsync(Guid id) 
    {
        var userProfile = await _context.Users.FindAsync(id);
        if(userProfile is null)
        {
            return null;
        }
        return userProfile;
    }
}
