using ResturantApplication.Application.Room.Command.CreateRoom;
using Xunit;
using FluentValidation.TestHelper;
namespace ResturantApplication.Domain.Tests.Room.Command.CreateRoom;

public class CreateRoomValidatorTest
{
    [Fact()]
    public void ValidateCreateRoom()
    {
        //arrange
        var roomCommand = new CreateRoomCommand()
        {
            Name = "test",
            Description = "Hello",
        };
        var validator = new CreateRoomValidator();
        //act
        var result = validator.TestValidate(roomCommand);
        //assert
        Assert.True(result.IsValid);
        result.ShouldNotHaveAnyValidationErrors();
    }
}