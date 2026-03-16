using MediatR;
using Microsoft.AspNetCore.Identity;
using ResturantApplication.Domain.Exception;

namespace ResturantApplication.Application.Role.UnAssigningRole;

public class UnAssigningRoleHandler(UserManager<Domain.Entities.User> userManager,RoleManager<IdentityRole> roleManager):IRequestHandler<UnAssigningRoleCommand>
{
    public async Task Handle(UnAssigningRoleCommand request, CancellationToken cancellationToken)
    {
        var user=await userManager.FindByNameAsync(request.Email);
        if(user==null)
            throw new Exception("User not found");
        var role=await roleManager.FindByNameAsync(request.RoleName);
        if (role == null)
        {
            throw new Exception("Role isnot assigned");
        }

        if (!roleManager.RoleExistsAsync(role.Name).Result)
        {
            throw new Exception("Role does not exist");
        }
        await userManager.RemoveFromRoleAsync(user,role.Name);
    }
}