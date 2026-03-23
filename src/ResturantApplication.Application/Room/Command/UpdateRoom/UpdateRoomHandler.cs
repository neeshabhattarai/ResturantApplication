using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ResturantApplication.Application.Room.DTOs;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Room.Command.UpdateRoom;

public class UpdateRoomHandler(IMapper mapper,IRoomRepository repository,ILogger<UpdateRoomHandler> logger):IRequestHandler<UpdateRoomCommand>
{
    public async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var result =await repository.GetById(request.Id);
        if (result == null)
            throw new NotFoundException(nameof(Room), request.Id);
        logger.LogInformation(request.ToString());
        mapper.Map(request, result);
        
        await repository.SaveChanges();
        
        // return mapper.Map<UpdateRoomCommand>(result) ;
    }
}