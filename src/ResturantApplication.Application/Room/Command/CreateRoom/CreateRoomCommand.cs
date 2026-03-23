using MediatR;

namespace ResturantApplication.Application.Room.Command.CreateRoom;

public class CreateRoomCommand:IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}