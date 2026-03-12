using MediatR;
using ResturantApplication.Application.Room.DTOs;
namespace ResturantApplication.Application.Room.Queries;

public class GetAllRoomQuery:IRequest<List<RoomDTo>>
{}
