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
  [Authorize(Roles = UserRole.Admin)]
  // [Authorize(Policy = "HasIdentityRole")]]
  [Authorize(Policy = "IsEmail")]
  [HttpGet("debug")]
  public IActionResult Debug()
  {
    var claims = User.Claims.Select(c => new { c.Type, c.Value });
    return Ok(claims);
  }
  [Authorize(Roles = UserRole.Admin)]
  [HttpPost]
  public async Task<IActionResult> UnAssigningRole([FromBody] UnAssigningRoleCommand command)
  {
    await mediator.Send(command);
    return NoContent();
  }
}