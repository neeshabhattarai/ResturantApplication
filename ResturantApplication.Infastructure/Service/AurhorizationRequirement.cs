using Microsoft.AspNetCore.Authorization;
using ResturantApplication.Application.User;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Infastructure.Service;

public class AurhorizationRequirement(IUserContext userContext):IRequirementAuthorization
{
    public bool Authorize(ResourcesOperation resourcesOperation, Room romm)
    {
        var user =userContext.GetCurrentUser();
        if (resourcesOperation == ResourcesOperation.Create || resourcesOperation == ResourcesOperation.Read)
        {
            return true;
        }
        
        if (resourcesOperation == ResourcesOperation.Delete && user.Id == romm.UserId)
        {
            return true;
        }

        return false;
    }
}