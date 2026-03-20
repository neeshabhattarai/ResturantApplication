using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResturantApplication.Application.PageResult;
using ResturantApplication.Application.Room.DTOs;
namespace ResturantApplication.Application.Room.Queries;

public class GetAllRoomQuery :IRequest<PageResult<RoomDTo>>
{
    public string? searchParams{get;set;}
    public int pageNumber{get;set;}
    
    public int pageSize{get;set;}
    public string? sortBy{get;set;}
    public string? sortDirection{get;set;}
}
