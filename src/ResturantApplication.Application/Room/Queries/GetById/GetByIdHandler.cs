using AutoMapper;
using MediatR;
using ResturantApplication.Application.Room.DTOs;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Room.Queries.GetById;

public class GetByIdHandler(IRoomRepository repo,IMapper mapper):IRequestHandler<GetByIdQuery,RoomDTo?>
{
    public async Task<RoomDTo?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
      
       var result=await repo.GetById(request.Id);
       if (result == null)
           throw new NotFoundException(nameof(Room), request.Id);
       return mapper.Map<RoomDTo>(result)!;

    }
}