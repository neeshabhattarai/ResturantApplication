using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Domain.Repository;

public interface IRoomRepository
{
   List<Room> GetAllAsync();
}