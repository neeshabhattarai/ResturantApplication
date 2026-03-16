using Microsoft.AspNetCore.Identity;
using ResturantApplication.Infastructure.Constant;
using ResturantApplication.Infastructure.Data;

namespace ResturantApplication.Infastructure.DataSeed;

public class RoleSeed(ApplicationDbContext context,RoleManager<IdentityRole> roleManager):IRoleSeed
{
    public async Task Seed()
    {
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new(UserRole.User.ToUpper()),
            new(UserRole.Admin.ToUpper()),
            new(UserRole.Manager.ToUpper())

        };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }

    }
}