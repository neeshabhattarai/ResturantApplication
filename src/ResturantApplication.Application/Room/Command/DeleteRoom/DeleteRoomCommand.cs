using MediatR;

namespace  ResturantApplication.Application.Room.Command.DeleteRoom;

public class DeleteRoomCommand(int id):IRequest
{
    public int Id { get;  } = id;
}