using AutoMapper;
using MediatR;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Room.Command.CreateRoom;

public class CreateRoomHandler(IRoomRepository repository,IMapper mapper):IRequestHandler<CreateRoomCommand,int>
{
    public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
       var response= await repository.CreateRoom(mapper.Map<Domain.Entities.Room>(request));
       return response.Id;
    }
}