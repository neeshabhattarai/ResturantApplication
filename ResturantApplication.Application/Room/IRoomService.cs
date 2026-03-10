using ResturantApplication.Application.Room.DTOs;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Application.Service;

public interface IRoomService
{
    List<Domain.Entities.Room> GetAllRooms();
    Task<AddRoomDTo> Create(AddRoomDTo room);
}