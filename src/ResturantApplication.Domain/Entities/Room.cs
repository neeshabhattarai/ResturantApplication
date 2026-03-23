using System.ComponentModel.DataAnnotations;

namespace ResturantApplication.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Dish> Dishes { get; set; }=new List<Dish>();
    public User User { get; set; }
    public string UserId { get; set; }
}