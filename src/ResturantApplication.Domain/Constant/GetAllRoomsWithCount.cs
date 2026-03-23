
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Domain.Constant;

public class GetAllRoomsWithCount
{
    public List<Room> Rooms{get;set;}
    public int totalCount{get;set;}
}