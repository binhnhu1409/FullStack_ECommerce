
namespace backend.src.Services.AuthService;

using backend.src.DTOs;
using backend.src.Models;
using backend.src.Helpers;
using backend.src.Repositories.AuthRepo;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
    private readonly IAuthRepo _repository;
    private readonly IConfiguration _config;

    public AuthService(IAuthRepo repository, IConfiguration config) 
    {
        _repository = repository;
        _config = config;
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
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        var secret = _config["AppSettings:Token"];
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = credentials,
            Expires = DateTime.Now.AddDays(7)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
