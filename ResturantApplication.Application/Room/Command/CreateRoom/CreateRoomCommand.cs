using MediatR;

namespace ResturantApplication.Application.Room.Command.CreateRoom;

public class CreateRoomCommand:IRequest<int>
{
    public int Id =new Random().Next();
    public string Name { get; set; }
    public string Description { get; set; }
}