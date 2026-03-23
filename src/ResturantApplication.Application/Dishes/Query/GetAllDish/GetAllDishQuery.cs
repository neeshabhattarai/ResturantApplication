using MediatR;
using ResturantApplication.Application.Dishes.DTO;

namespace ResturnatApplication.Dishes.Query.GetAll;

public class GetAllDishQuery(int RoomId):IRequest<List<DishDTO>>
{
    public int RoomId { get; } = RoomId;
}

