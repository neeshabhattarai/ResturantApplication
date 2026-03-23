using ResturantApplication.Application.User;

namespace ResturantApplication.Domain.Tests;
using Xunit;

public class CurrentUser
{
    [Fact]
    public void CurrentUserContext_ShouldReturnTrue()
    {
        var user = new Application.User.CurrentUser("test@gmail.com", "test@gmail.com", ["Admin", "User"]);
        Assert.True(user.IsInRole("Admin"));
        

    }
}