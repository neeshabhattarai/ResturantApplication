using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Repository;
namespace ResturantApplication.Application.Service;

public class RoomService: IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public List<Room> GetAllRooms()
    {
        return _roomRepository.GetAllAsync();
    }
    
}