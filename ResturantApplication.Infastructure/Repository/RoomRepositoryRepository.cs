using Microsoft.EntityFrameworkCore;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Data;

namespace ResturantApplication.Infastructure.Repository;

public class RoomRepositoryRepository:IRoomRepository
{
    private readonly ApplicationDbContext _context;
    private IRoomRepository _roomRepositoryImplementation;

    public RoomRepositoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Room> GetAll()

    {
        // throw new Exception("This repository doesn't support getting all rooms");
        var roomDetails = _context.Rooms.ToList();
        return roomDetails;
    }

    public async Task<Room> CreateRoom(Room room)
    {
       await _context.Rooms.AddAsync(room);
       await _context.SaveChangesAsync();
        return room;
    }

    public async Task<Room?> GetById(int id)
    {
        var result =await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task DeleteRoom(Room roomdetails)
    {
        
        _context.Rooms.Remove(roomdetails);
        await _context.SaveChangesAsync();
        
    }

    public Task SaveChanges()
    {
        return _context.SaveChangesAsync();
    }
}