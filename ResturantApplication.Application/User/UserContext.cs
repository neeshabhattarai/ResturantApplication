using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace  ResturantApplication.Application.User;

public interface IUserContext
{
    public CurrentUser GetCurrentUser();
}

public class UserContext(IHttpContextAccessor accessor) : IUserContext
{
    public CurrentUser GetCurrentUser()
    {
        var user = accessor.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidOperationException("User context not found please login first");
        }

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var Id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var Email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        return new CurrentUser(Id, Email, roles);
    }
}