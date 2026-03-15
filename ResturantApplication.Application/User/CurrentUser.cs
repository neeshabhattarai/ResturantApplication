namespace ResturantApplication.Application.User;

public record CurrentUser(string Id,string Email,IEnumerable<string>roles)
{
    public bool IsInRole(string role)
    {
        return roles.Contains(role);
    }
}