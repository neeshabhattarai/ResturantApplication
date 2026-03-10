using AutoMapper;
using ResturantApplication.Application.Room.DTOs;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Repository;
namespace ResturantApplication.Application.Service;

public class RoomService: IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomService(IRoomRepository roomRepository,IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public List<Domain.Entities.Room> GetAllRooms()
    {
        return _roomRepository.GetAllAsync();
    }

    public async Task<AddRoomDTo> Create(AddRoomDTo room)
    {
        
       var result=await _roomRepository.CreateRoom(_mapper.Map<Domain.Entities.Room>(room));
       return _mapper.Map<AddRoomDTo>(result);
    }
}