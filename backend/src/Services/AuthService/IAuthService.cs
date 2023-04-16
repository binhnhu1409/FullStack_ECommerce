namespace backend.src.Services.AuthService;

using backend.src.DTOs;

public interface IAuthService
{
    Task<string> LogInAsync(AuthDTO auth);
}
