using FluentValidation;

namespace ResturantApplication.Application.Dishes.Command.CreateDish;

public class CreateDishValidator:AbstractValidator<CreateDishCommand>
{
    public CreateDishValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(3,50).WithMessage("Name must be between 3 and 50 characters");
        RuleFor(x=>x.calories).GreaterThanOrEqualTo(0).WithMessage("Calories must be not be negative");
    }
}