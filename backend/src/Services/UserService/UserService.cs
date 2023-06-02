namespace backend.src.Services.UserService;

using AutoMapper;
using backend.src.DTOs;
using backend.src.Services.BaseService;
using backend.src.Models;
using backend.src.Repositories.UserRepo;
using System.Threading.Tasks;

public class UserService
    : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
{   
    private readonly IUserRepo _repo;
    
    public UserService(IMapper mapper, IUserRepo repo) 
        : base(mapper, repo)
    {
        _repo = repo;
    }

    public async Task<UserReadDto?> GetUserProfileAsync(string userId)
    {
        var result = await _repo.GetUserProfileAsync(userId);
        if(result is null)
        {
            return null;
        }
        return _mapper.Map<User, UserReadDto>(result);
    }
}
