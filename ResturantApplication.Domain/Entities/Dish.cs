using System.ComponentModel.DataAnnotations;

namespace ResturantApplication.Domain.Entities;

public class Dish
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int calories { get; set; }
}