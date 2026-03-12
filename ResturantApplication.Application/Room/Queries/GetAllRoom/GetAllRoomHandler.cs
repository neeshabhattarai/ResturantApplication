using AutoMapper;
using MediatR;
using ResturantApplication.Application.Room.DTOs;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Room.Queries;

public class GetAllRoomHandler(IMapper mapper,IRoomRepository repo):IRequestHandler<GetAllRoomQuery,List<RoomDTo>>
{
    public Task<List<RoomDTo>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(mapper.Map<List<RoomDTo>>(repo.GetAll()));
    }
}