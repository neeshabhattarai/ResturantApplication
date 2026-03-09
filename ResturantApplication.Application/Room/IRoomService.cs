using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Application.Service;

public interface IRoomService
{
    List<Room> GetAllRooms();
}