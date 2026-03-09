namespace ResturantApplication.Application.Room.DTOs;

public class AddRoomDTo
{
    public int Id { get; set; }=new Random().Next();
    public string Name { get; set; }
    public string Description { get; set; }
}