using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResturantApplication.Domain.Constant;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Data;
using ResturantApplication.Infastructure.Service;

namespace ResturantApplication.Infastructure.Repository;

public class RoomRepositoryRepository:IRoomRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RoomRepositoryRepository> _logger;

    public RoomRepositoryRepository(ApplicationDbContext context,ILogger<RoomRepositoryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<(IEnumerable<Room>,int)> GetAll(string? searchParams, int pageNumber, int pageSize,string? sortBy,string? sortDirection)

    {
        // throw new Exception("This repository doesn't support getting all rooms");
        _logger.LogInformation($"Searching for rooms with {searchParams}");
        var roomDetails = _context.Rooms.Where(r =>
            searchParams == null || r.Name.Contains(searchParams) || r.Description.Contains(searchParams));
        roomDetails.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        var totalCount=await roomDetails.CountAsync();
        if (sortBy != null)
        {
            var containedString=new Dictionary<string,Expression<Func<Room, object>>>
            {
                {nameof(Room.Name),r=>r.Name},
                {nameof(Room.Description),r=>r.Description}
            };
            var sortedResult=containedString[sortBy];
            roomDetails=SortDirection.Ascending==sortDirection
                ? roomDetails.OrderBy(sortedResult)
                : roomDetails.OrderByDescending(sortedResult);
            
        }
        return (roomDetails.ToList(),totalCount);
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