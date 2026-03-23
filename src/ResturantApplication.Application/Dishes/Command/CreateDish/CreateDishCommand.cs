using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ResturantApplication.Application.Dishes.Command.CreateDish;

public class CreateDishCommand:IRequest<int>
{
    public string Name { get; set; }
    public int calories { get; set; }
    [JsonIgnore]
    public int RoomId{ get; set; }
}