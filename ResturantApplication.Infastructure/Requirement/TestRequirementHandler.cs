using Microsoft.AspNetCore.Authorization;

namespace ResturantApplication.Infastructure.Requirement;

public class TestRequirementHandler:AuthorizationHandler<TestRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestRequirement requirement)
    {
        if(requirement.age>20)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        context.Fail();
        return Task.CompletedTask;
    }
}