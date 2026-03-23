using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ResturantApplication.Api.Tests.Controller;

public class RoomControllerTest:IClassFixture<WebApplicationFactory<Program>>
{
    public HttpClient client;

    public RoomControllerTest(WebApplicationFactory<Program> builder)
    {
        client = builder.CreateClient();

    }

    [Fact]
    public async void RoomController_ShouldReturnOkResult()
    {
       var result=await client.GetAsync("/api/Room");
       Assert.True(result.IsSuccessStatusCode);
        
    }
}