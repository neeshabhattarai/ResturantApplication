using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Data;
using ResturantApplication.Infastructure.Repository;

namespace ResturantApplication.Infastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IRoomRepository, RoomRepositoryRepository>();
    }
}