using Microsoft.EntityFrameworkCore;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Data;

namespace ResturantApplication.Infastructure.Repository;

public class DishRepository(ApplicationDbContext _context):IDish
{
    

    public async Task<Room> GetAll(int roomId)
    {
      var result=await _context.Rooms.Include("Dishes").FirstOrDefaultAsync(z=>z.Id==roomId);
      if (result == null)
      {
          throw new NotFoundException(nameof(Room), roomId);
      }
      return result;
    }

    public async Task<int> CreateDish(Dish dish)
    {
       await _context.Dish.AddAsync(dish);
       await _context.SaveChangesAsync();
       return dish.Id;
    }

    

    public async Task<Dish> GetById(int roomId,int dishId)
    {
        var result = await _context.Rooms.Include("Dishes").FirstOrDefaultAsync(z => z.Id == roomId );
        
        if(result==null)
            throw new NotFoundException(nameof(Dish),roomId);
        result.Dishes = result.Dishes.Where(x=>x.Id==dishId).ToList();
        return result.Dishes.FirstOrDefault();
    }

    public async Task DeleteRoom(IEnumerable<Dish> dishes)
    {
        _context.Dish.RemoveRange(dishes);
      await  _context.SaveChangesAsync();
        
    }
}