using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ResturantApplication.Application.Dishes;
using ResturantApplication.Application.Dishes.DTO;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;
using ResturnatApplication.Application.Dishes.Query.GetByIdDish;

namespace ResturnatApplication.Dishes.Query.GetByIdDish;
public class GetDishByIdHandler(IRoomRepository repository,ILogger<GetDishByIdHandler>logger,IDish dishRepo,IMapper mapper):IRequestHandler<GetDishByIdQuery,DishDTO>
{
    public async Task<DishDTO> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        var dish= await dishRepo.GetById(request.RoomId,request.DishId);
        if (dish==null)
        {
            throw new NotFoundException(nameof(Dish), request.DishId);
        }
        return mapper.Map<DishDTO>(dish);
    }
}

