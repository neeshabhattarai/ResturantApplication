using MediatR;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Room.Command.DeleteRoom;

public class DeleteRoomHandler(IRoomRepository repository):IRequestHandler<DeleteRoomCommand>
{
    public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
      var result= await repository.GetById(request.Id);
      if(result == null)
          throw new NotFoundException(nameof(Room), request.Id);
    }
}