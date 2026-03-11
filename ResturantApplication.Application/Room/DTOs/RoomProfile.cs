using AutoMapper;
using ResturantApplication.Application.Room.Command.CreateRoom;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Application.Room.DTOs;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<RoomDTo,Domain.Entities.Room>().ReverseMap();
        CreateMap<CreateRoomCommand, Domain.Entities.Room>().ReverseMap();
    }
}