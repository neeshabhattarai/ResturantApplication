using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResturantApplication.Application.PageResult;
using ResturantApplication.Application.Room.DTOs;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Application.Room.Queries;

public class GetAllRoomHandler(IMapper mapper,IRoomRepository repo):IRequestHandler<GetAllRoomQuery,PageResult<RoomDTo>>
{
    public async Task<PageResult<RoomDTo>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        var (list, count)=await repo.GetAll(request.searchParams,request.pageNumber, request.pageSize,request.sortBy,request.sortDirection);
        var mapperList =mapper.Map<List<RoomDTo>>(list.ToList());
        return new PageResult<RoomDTo>(mapperList,count,request.pageSize, request.pageNumber,request.sortBy,request.sortDirection);
    }
}