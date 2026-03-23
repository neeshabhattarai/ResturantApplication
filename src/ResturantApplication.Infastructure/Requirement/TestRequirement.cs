using Microsoft.AspNetCore.Authorization;

namespace ResturantApplication.Infastructure.Requirement;

public class TestRequirement(int age):IAuthorizationRequirement
{
    public int age { get; } = age;
}