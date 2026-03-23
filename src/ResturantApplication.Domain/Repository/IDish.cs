using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Domain.Repository;

public interface IDish
{
    Task<Room> GetAll(int roomId);
    Task<int> CreateDish(Dish dish);
    Task<Dish> GetById(int roomId,int dishId);
    Task DeleteRoom(IEnumerable<Dish> dishes);
}