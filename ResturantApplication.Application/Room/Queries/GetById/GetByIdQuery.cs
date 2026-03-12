using MediatR;
using ResturantApplication.Application.Room.DTOs;

namespace ResturantApplication.Application.Room.Queries.GetById;

public class GetByIdQuery (int id): IRequest<RoomDTo?>
{
    public int Id { get;  } = id;
}