using MediatR;
using Microsoft.AspNetCore.Identity;
using ResturantApplication.Domain.Exception;

namespace ResturantApplication.Application.Role.Command.AssignRole;

public class AssignRoleHandler(UserManager<Domain.Entities.User> userManager,RoleManager<IdentityRole> roleManager):IRequestHandler<AssignRoleCommand>
{
    public async Task Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        var user =await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var roleNames =await roleManager.FindByNameAsync("User");
        await userManager.AddToRoleAsync(user,roleNames.Name);
    }
}