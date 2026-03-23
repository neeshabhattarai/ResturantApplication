using AutoMapper;
using ResturantApplication.Application.Dishes.Command.CreateDish;
using ResturantApplication.Application.Dishes.DTO;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Application.Dishes;

public class DishMapper:Profile
{
  public DishMapper()
  {
    CreateMap<Dish,DishDTO>().ReverseMap();
    CreateMap<CreateDishCommand,Dish>().ReverseMap(); 
  }  
}