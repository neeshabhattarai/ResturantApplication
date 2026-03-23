using AutoMapper;
using ResturantApplication.Application.Room.Command.CreateRoom;
using ResturantApplication.Application.Room.DTOs;

namespace ResturantApplication.Domain.Tests.Room.Command.CreateRoom;

public class CreateRoomMapperTest
{
    public IMapper _mapper;
    public CreateRoomMapperTest()
    {
        _mapper =new MapperConfiguration(cfg => cfg.AddProfile<RoomProfile>()).CreateMapper();
    }

    [Fact]
    public void RoomProfileMapper_ShouldMapToRoom()
    {
        var Room = new CreateRoomCommand
        {
            Name = "Room",
            Description = "Description",
        };
       var result= _mapper.Map<Entities.Room>(Room);
        
       Assert.Equal("Room", result.Name);
        Assert.Equal("Description", result.Description);

    }
}