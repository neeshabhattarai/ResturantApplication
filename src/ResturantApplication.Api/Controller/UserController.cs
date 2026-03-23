using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResturantApplication.Application.User.Command.UpdateUser;

namespace ResturantApplication.Controller;
[ApiController]
[Route("api/Identity")]
public class UserController(IMediator mediator):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand request)
    {
       await mediator.Send(request);
       return NoContent();
    }
    
    
}