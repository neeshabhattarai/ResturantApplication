using Microsoft.AspNetCore.Http;
using Moq;
using RestuarantApplication.Api.Extensions;

namespace ResturantApplication.Api.Tests.Middleware;

public class ExceptionHandlerTest
{
    public Mock<RequestDelegate> next;
    public HttpContext context;
    public ExceptionHandlerTest()
    {
        next=new Mock<RequestDelegate>();
        context = new DefaultHttpContext();
    }
    [Fact]
    public void InvokeAsync_ShouldCalledNext()
    {
        var excepitonHandler = new ExceptionHandler();
       var result=  excepitonHandler.InvokeAsync(context, next.Object);
       next.Verify(r=>r.Invoke(context), Times.Once);
       Assert.True(result.IsCompletedSuccessfully);
    }

    [Fact]
    public void InvokeAsync_ShouldNotInvokeNext()
    {
        var excepitonHandler = new ExceptionHandler();
        
        var exception=new Exception("Something went wrong");
        next.Setup(r=>r.Invoke(context)).Returns(Task.FromResult(exception));
        var result=  excepitonHandler.InvokeAsync(context, _=>throw exception);
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        next.Verify(r=>r.Invoke(context), Times.Never);
    }
}