namespace backend.src.Controller;

using Microsoft.AspNetCore.Mvc;
using backend.src.DTOs;
using backend.src.Services.AuthService;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<string> LogInAsync([FromBody]AuthDTO auth)
    {
        return await _service.LogInAsync(auth);
    }
}
