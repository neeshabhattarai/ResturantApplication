using System.Collections.Immutable;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ResturantApplication.Application.Dishes.DTO;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;

namespace ResturnatApplication.Dishes.Query.GetAll;

public class GetAllDishHandler(IDish repository,IMapper mapper):IRequestHandler<GetAllDishQuery,List<DishDTO>>
{
    public async Task<List<DishDTO>> Handle(GetAllDishQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAll(request.RoomId);
       if (result == null)
       {
           throw new NotFoundException(nameof(Room), request.RoomId);
       }
       ;
       Console.WriteLine(result.Dishes.ToList());
        // result.Dishes = mappedDish;
        // Console.WriteLine(mappedDish);
       return mapper.Map<List<DishDTO>>(result.Dishes);
    }
}