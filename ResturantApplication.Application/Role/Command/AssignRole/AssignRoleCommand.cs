using MediatR;

namespace ResturantApplication.Application.Role.Command.AssignRole;

public class AssignRoleCommand:IRequest
{
    public string Email{get;set;}
    public string RoleNames { get; set; }
}