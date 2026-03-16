using MediatR;

namespace  ResturantApplication.Application.Role.UnAssigningRole;

public class UnAssigningRoleCommand:IRequest
{
    public string Email { get; set; }
    public string RoleName { get; set; }
}