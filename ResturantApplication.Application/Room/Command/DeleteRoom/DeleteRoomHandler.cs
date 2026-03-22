using MediatR;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Service;

namespace ResturantApplication.Application.Room.Command.DeleteRoom;

public class DeleteRoomHandler(IRoomRepository repository,IRequirementAuthorization requirementAuthorization):IRequestHandler<DeleteRoomCommand>
{
    public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
      var result= await repository.GetById(request.Id);
      if ( requirementAuthorization.Authorize(ResourcesOperation.Delete, result) == false)
      {
          throw new Exception("You do not have permission to delete this room");
      }
      
      if(result == null)
          throw new NotFoundException(nameof(Room), request.Id);
      repository.DeleteRoom(result);
    }
    
}