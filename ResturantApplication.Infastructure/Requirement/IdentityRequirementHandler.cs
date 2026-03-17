using Microsoft.AspNetCore.Authorization;
using ResturantApplication.Application.User;

namespace ResturantApplication.Infastructure.Requirement;

public class IdentityRequirementHandler(IUserContext userContext):AuthorizationHandler<IdentityRequried>
{
    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdentityRequried requirement)
    {
        var user =  userContext.GetCurrentUser();
        if(user.Email==requirement.Name)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}