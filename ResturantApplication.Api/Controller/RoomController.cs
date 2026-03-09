using Microsoft.AspNetCore.Mvc;
using ResturantApplication.Application.Service;

namespace ResturantApplication.Controller;
[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_roomService.GetAllRooms());
    }
}