using AutoMapper;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Application.Room.DTOs;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<AddRoomDTo,Domain.Entities.Room>().ReverseMap();
    }
}