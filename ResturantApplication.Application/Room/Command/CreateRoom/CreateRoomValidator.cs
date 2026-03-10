using FluentValidation;
using FluentValidation.AspNetCore;
using ResturantApplication.Application.Room.DTOs;

namespace ResturantApplication.Application.Room.Command.CreateRoom;

public class CreateRoomValidator : AbstractValidator<AddRoomDTo>
{
    private string[] deslist={"Hello", "World"};
    public CreateRoomValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(4,100).WithMessage("Name must be between 4 and 100 characters");
        RuleFor(x => x.Description).Must(deslist.Contains).WithMessage("Description must be between hello and world characters");
    }
}
