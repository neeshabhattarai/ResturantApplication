using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantApplication.Application.Role.Command.AssignRole;

namespace ResturantApplication.Controller;
[ApiController]
[Route("/api/Identity/assignRole")]
[Authorize]
public class AssignRoleControllerI(IMediator mediator):ControllerBase
{
   [ProducesResponseType(StatusCodes.Status200OK)]
   [HttpPost]
   public async Task<IActionResult> AssignRole(AssignRoleCommand roleCommand)
   {
      await mediator.Send(roleCommand);
      return Ok();
   }
   
}