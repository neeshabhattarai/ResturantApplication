using MediatR;
using Microsoft.AspNetCore.Identity;
using ResturantApplication.Domain.Exception;

namespace ResturantApplication.Application.User.Command.UpdateUser;

public class UpdateUserHandler(IUserContext context,IUserStore<Domain.Entities.User> userStore):IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = context.GetCurrentUser();
        var userDetails=await userStore.FindByIdAsync(user!.Id,cancellationToken);
        if (userDetails == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.User),Int16.Parse(user.Id));
        }

        userDetails.Identity = request.Identity; 
        await userStore.UpdateAsync(userDetails, cancellationToken);
    }
}