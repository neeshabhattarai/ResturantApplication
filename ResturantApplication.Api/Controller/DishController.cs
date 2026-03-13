using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResturantApplication.Application.Dishes.Command.CreateDish;
using ResturantApplication.Application.Dishes.Command.DeleteDish;
using ResturnatApplication.Application.Dishes.Query.GetByIdDish;
using ResturnatApplication.Dishes.Query.GetAll;

namespace ResturantApplication.Controller;

[ApiController]
[Route("api/rooms/{roomId}/dishes")]
public class DishController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<DishController> _logger;

    public DishController(IMediator mediator, ILogger<DishController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromRoute]int roomId)
    {
       var result=await _mediator.Send(new GetAllDishQuery(roomId));
       return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route("{dishId}")]
    public async Task<IActionResult> GetById([FromRoute] int roomId, [FromRoute]int dishId)
    {
        var result = await _mediator.Send(new GetDishByIdQuery(roomId, dishId));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDish([FromBody] CreateDishCommand dish, [FromRoute] int roomId)
    {
        dish.RoomId=roomId;
        Console.WriteLine(dish.ToString());
        var id=await _mediator.Send(dish);
        return CreatedAtAction(nameof(GetById), new { roomId, dishId = id }, id);
    }
  [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDish([FromRoute] int roomId)
    {
        // throw new UnreachableException();
        await _mediator.Send(new DeleteDishQuery(roomId));
        return NoContent();
    }
}
