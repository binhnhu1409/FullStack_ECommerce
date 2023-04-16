
namespace backend.src.Services.AuthService;

using backend.src.DTOs;
using backend.src.Models;
using backend.src.Helpers;
using backend.src.Repositories.AuthRepo;

public class AuthService : IAuthService
{
    private readonly IAuthRepo _repository;

    public AuthService(IAuthRepo repository) 
    {
        _repository = repository;
    }
    public async Task<string> LogInAsync(AuthDTO auth)
    {
        var user = await _repository.LogInAsyn(auth);
        if(user is null)
        {
            throw CustomizedException.Unauthorized("Invalid email or password!");
        }
        return CreateToken(user);
    }

    private string CreateToken(User user) 
    {
        
    }
}
