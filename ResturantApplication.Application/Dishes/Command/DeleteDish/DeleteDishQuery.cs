using MediatR;
using ResturantApplication.Application.Dishes.DTO;

namespace  ResturantApplication.Application.Dishes.Command.DeleteDish;

public class DeleteDishQuery(int roomid):IRequest
{
    public int RoomId { get; set; } = roomid;
}