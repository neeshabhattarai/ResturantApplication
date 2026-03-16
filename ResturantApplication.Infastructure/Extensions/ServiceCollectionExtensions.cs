using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Authorization;
using ResturantApplication.Infastructure.Data;
using ResturantApplication.Infastructure.Repository;

namespace ResturantApplication.Infastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IRoomRepository, RoomRepositoryRepository>();
        services.AddIdentityApiEndpoints<User>().AddClaimsPrincipalFactory<IdentityRoleClaim>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddScoped<IDish, DishRepository>();
        services.AddAuthorizationBuilder().AddPolicy("HasIdentityRole", builder => builder.RequireClaim("Identity"));
    }
}