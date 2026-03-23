using ResturantApplication.Domain.Constant;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Domain.Repository;

public interface IRoomRepository
{
   Task<(IEnumerable<Room>,int)> GetAll(string? searchParams,int pageNumber,int pageSize,string? sortBy,string? sortDirection);
   Task<Room> CreateRoom(Room room);
   Task<Room?> GetById(int id);
   Task DeleteRoom(Room roomdetails);
   Task SaveChanges();
}