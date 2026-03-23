using MediatR;

namespace ResturantApplication.Application.User.Command.UpdateUser;
public class UpdateUserCommand:IRequest
{
    public string Identity { get; set; }
}