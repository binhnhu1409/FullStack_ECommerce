
namespace backend.src.Authorization;

using System.Security.Claims;
using System.Threading.Tasks;
using backend.src.Models;
using Microsoft.AspNetCore.Authorization;

public class UpdateUserRequirement : IAuthorizationRequirement { }

public class UpdateUserHandler : AuthorizationHandler<UpdateUserRequirement, User>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UpdateUserRequirement requirement, User resource)
    {
        var userRole = context.User.FindFirstValue(ClaimTypes.Role);
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userRole == Role.Admin.ToString())
        {
            context.Succeed(requirement);
        } 
        // verify if user tries to edit their own profile
        else if (userId! == resource.Id.ToString())
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
