using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Data;

namespace ResturantApplication.Infastructure.Repository;

public class RoomRepositoryRepository:IRoomRepository
{
    private readonly ApplicationDbContext _context;

    public RoomRepositoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Room> GetAllAsync()

    {
        var roomDetails = _context.Rooms.ToList();
        return roomDetails;
    }
}