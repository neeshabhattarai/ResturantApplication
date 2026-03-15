using Microsoft.AspNetCore.Identity;
using ResturantApplication.Infastructure.Constant;
using ResturantApplication.Infastructure.Data;

namespace ResturantApplication.Infastructure.DataSeed;

public class RoleSeed(ApplicationDbContext context):IRoleSeed
{
    public async Task Seed()
    {
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new(UserRole.User),
            new(UserRole.Admin),
            new(UserRole.Manager)

        };
        if (!context.Roles.Any())
        {
            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }
        
    }
}