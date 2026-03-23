using MediatR;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Dishes.Command.DeleteDish;

public class DeleteDishHandler(IDish dishRepo,IRoomRepository roomRepository):IRequestHandler<DeleteDishQuery>
{
    public async Task Handle(DeleteDishQuery request, CancellationToken cancellationToken)
    {
        var roomDetails=await dishRepo.GetAll(request.RoomId);
        if(roomDetails==null)
            throw new NotFoundException(nameof(Room), request.RoomId);
        await dishRepo.DeleteRoom(roomDetails.Dishes);
        
    }
}