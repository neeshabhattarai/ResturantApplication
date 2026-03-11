using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Domain.Repository;

public interface IRoomRepository
{
   List<Room> GetAll();
   Task<Room> CreateRoom(Room room);
   Task<Room?> GetById(int id);
   Task<bool> DeleteRoom(int requestId);
   Task SaveChanges();
}