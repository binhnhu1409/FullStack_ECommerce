namespace backend.src.Repositories.AuthRepo;

using backend.src.Models;
using backend.src.Database;
using backend.src.DTOs;
using Microsoft.EntityFrameworkCore;

public class AuthRepo : IAuthRepo
{
    private readonly DatabaseContext _context;
    public AuthRepo(DatabaseContext context)
    {
        _context = context;
    }
    public Task<User> AuthenticatedUserAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<User?> LogInAsyn(AuthDTO auth)
    {
        var user = _context.Users.FirstOrDefaultAsync(u => u.Email == auth.Email && u.Password == auth.Password);
        return user;
    }

}
