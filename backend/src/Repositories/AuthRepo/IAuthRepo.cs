namespace backend.src.Repositories.AuthRepo;

using backend.src.Models;
using backend.src.DTOs;

public interface IAuthRepo
{
    Task<User?> LogInAsyn (AuthDTO auth);
}
