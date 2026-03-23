using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Moq;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Domain.Tests;

public class UserContext
{

    [Fact]
    public void UserContext_ShouldReturnTrue()
    {
        //arrange
        var HttpContextAccessor=new Mock<IHttpContextAccessor>();
        var UserContext=new Application.User.UserContext(HttpContextAccessor.Object);
      var claims=new List<Claim>
      { 
          new (ClaimTypes.Email,"test@gmail.com"),
          new (ClaimTypes.Role,"Admin"),
          new (ClaimTypes.NameIdentifier,"test@gmail.com"),
          
      };
      var usercalims=new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));
      HttpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
      {
          User=usercalims
      });
      
      //act
      var user = UserContext.GetCurrentUser();
      
      //assure
      Assert.True(user.IsInRole("Admin"));
      Assert.Equal(user.Email,"test@gmail.com");

    }
}