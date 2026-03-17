using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Infastructure.Data;

namespace ResturantApplication.Infastructure.Authorization;

public class IdentityRoleClaim : UserClaimsPrincipalFactory<User, IdentityRole>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IOptions<IdentityOptions> _optionsAccessor;

    public IdentityRoleClaim(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager,roleManager, optionsAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _optionsAccessor = optionsAccessor;
    }

    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);
        if (user.Identity != null)
        {
            id.AddClaim(new Claim("Identity", user.Identity));
        }
        var roles= await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            Console.WriteLine(role);
            id.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        return new ClaimsPrincipal(id);
    }


}