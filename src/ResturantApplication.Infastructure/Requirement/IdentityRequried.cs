using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ResturantApplication.Infastructure.Requirement;

public class IdentityRequried(string Name):IAuthorizationRequirement
{
    public string Name { get; } = Name;
}