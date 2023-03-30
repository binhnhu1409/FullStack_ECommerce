namespace backend.src.Services.UserService;

using backend.src.Repositories;
using backend.src.Services.BaseService;
using backend.src.Models;
using backend.src.DTOs;

public interface IUserService : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
{
    
}
