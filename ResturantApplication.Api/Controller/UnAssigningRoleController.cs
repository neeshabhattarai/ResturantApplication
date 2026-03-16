using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantApplication.Application.Role.UnAssigningRole;
using ResturantApplication.Infastructure.Constant;

namespace ResturantApplication.Controller;
[ApiController]
[Route("api/[controller]")]
public class UnAssigningRoleController(IMediator mediator):ControllerBase
{
  [Authorize(Roles = "Admin")]
  [HttpPost]
  public async Task<IActionResult> UnAssigningRole([FromBody] UnAssigningRoleCommand command)
  {
    await mediator.Send(command);
    return NoContent();
  }
}