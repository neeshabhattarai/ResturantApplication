using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Dishes.Command.CreateDish;

public class CreateDishHandler(IRoomRepository repository,ILogger<CreateDishHandler> logger, IDish dishRepo, IMapper mapper)
    : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(request.RoomId.ToString());
        var roomDetails = await repository.GetById(request.RoomId);
        
        if (roomDetails== null)
        {
            throw new NotFoundException(nameof(Room), request.RoomId);
        }

        var result = mapper.Map<Dish>(request);
        await dishRepo.CreateDish(result);
        logger.LogInformation(result.ToString());
        roomDetails.Dishes.Add(result);
        await repository.SaveChanges();
        return result.Id;
    }
}