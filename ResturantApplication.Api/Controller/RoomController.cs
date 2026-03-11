using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResturantApplication.Application.Room.Command.CreateRoom;
using ResturantApplication.Application.Room.Command.DeleteRoom;
using ResturantApplication.Application.Room.Command.UpdateRoom;
using ResturantApplication.Application.Room.DTOs;
using ResturantApplication.Application.Room.Queries;
using ResturantApplication.Application.Room.Queries.GetById;

namespace ResturantApplication.Controller;
[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IMediator mediator;

    public RoomController(IMediator mediator)
    {
        this.mediator=mediator;
    }

    [HttpGet] public IActionResult GetAll()
    {
        return Ok(mediator.Send(new GetAllRoomQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomCommand createRoomCommand)
    {
        var result=await mediator.Send(createRoomCommand);
        // return Ok(result);
        return CreatedAtAction(nameof(GetById), new { id = result },createRoomCommand);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result =await mediator.Send(new GetByIdQuery(id));
        if (result==null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        var result =await mediator.Send(new DeleteRoomCommand(id));
        if (result)
            return NoContent();
        return NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateRoomCommand updateRoomCommand)
    {
        updateRoomCommand.Id = id;
        var result = await mediator.Send(updateRoomCommand);
        if (result==null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
}