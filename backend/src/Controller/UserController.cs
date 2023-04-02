namespace backend.src.Controller;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using backend.src.Models;
using backend.src.DTOs;
using backend.src.Repositories.BaseRepo;
using backend.src.Services.UserService;
using System.Security.Claims;

public class UserController
    : BaseController<User, UserReadDto, UserCreateDto, UserUpdateDto>
{
    public UserController(IUserService service) : base(service)
    {

    }

    [Authorize]
    [HttpGet()]
    public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery]QueryOptions options)
    {
        var role = User.FindFirstValue(ClaimTypes.Role)?.ToLower();
        if(role != "admin")
        {
            return Forbid();
        }
        return Ok(await _service.GetAllAsync(options));
    }

    [Authorize]
    [HttpPost("{id}")]
    public override async Task<ActionResult<UserReadDto?>> UpdateOne([FromRoute]string id, [FromBody]UserUpdateDto update)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)
        {
            return NotFound();
        }
        if(id != userId)
        {
            return Unauthorized();
        }
        return Ok(await _service.UpdateOneAsync(id, update));
    }
}
