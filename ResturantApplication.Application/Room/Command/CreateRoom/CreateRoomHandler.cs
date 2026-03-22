using AutoMapper;
using MediatR;
using ResturantApplication.Application.User;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Service;


namespace ResturantApplication.Application.Room.Command.CreateRoom;


public class CreateRoomHandler(IRoomRepository repository,IMapper mapper,IUserContext context,IRequirementAuthorization authorization):IRequestHandler<CreateRoomCommand,int>
{
    public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var reply = mapper.Map<Domain.Entities.Room>(request);
        reply.UserId =context.GetCurrentUser().Id;
        if (!authorization.Authorize(ResourcesOperation.Create, reply))
        {
            throw new Exception("You cannot create a room");
        }
       var response= await repository.CreateRoom(reply).ConfigureAwait(false);
       return response.Id;
    }
}