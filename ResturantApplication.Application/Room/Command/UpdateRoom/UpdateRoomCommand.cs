using MediatR;
using ResturantApplication.Application.Room.DTOs;

namespace ResturantApplication.Application.Room.Command.UpdateRoom;

public class UpdateRoomCommand : IRequest
{
   public int Id;
   public string Name { get; set; }
   public string Description { get; set; }
}

