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
        var role = User.FindFirst(ClaimTypes.Role)?.Value.ToLower();
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
        var userId = User.FindFirst(ClaimTypes.)
        if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
        {
            return NotFound();
        }
        if (id != userId)
        {
            // User is not authorized to update this profile
            return Unauthorized();
        }
        return Ok(await _service.UpdateOneAsync(id, update));
    }

}
