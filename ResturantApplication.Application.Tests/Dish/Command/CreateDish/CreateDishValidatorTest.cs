using ResturantApplication.Application.Dishes.Command.CreateDish;

namespace ResturantApplication.Domain.Tests.Dish.Command.CreateDish;

public class CreateDishValidatorTest
{
    [Fact]
    public void CreateDishValidator_ShouldReturn_NameMustBeBetween3And50()
    {
        var createdish = new CreateDishCommand()
        {
            calories = 10,
            Name = "Al",
            RoomId = 1
        };
        var createValidator = new CreateDishValidator();
        var result = createValidator.Validate(createdish); 
        Assert.False(result.IsValid);
        Assert.Equal("Name must be between 3 and 50 characters",result.Errors[0].ErrorMessage);
    }
}