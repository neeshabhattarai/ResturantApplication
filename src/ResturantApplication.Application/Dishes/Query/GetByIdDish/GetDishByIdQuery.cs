using MediatR;
using ResturantApplication.Application.Dishes;
using ResturantApplication.Application.Dishes.DTO;

namespace ResturnatApplication.Application.Dishes.Query.GetByIdDish;

public class GetDishByIdQuery(int roomId,int dishId) : IRequest<DishDTO>
{
    public int RoomId { get; } = roomId;
    public int DishId { get; } = dishId;
}