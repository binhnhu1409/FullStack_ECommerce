
namespace backend.src.Authorization;

using System.Threading.Tasks;
using backend.src.Models;
using Microsoft.AspNetCore.Authorization;

public class UpdateUserRequirement : IAuthorizationRequirement { }

public class UpdateUserPermission : AuthorizationHandler<UpdateUserRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UpdateUserRequirement requirement)
    {
        throw new NotImplementedException();
    }
}
