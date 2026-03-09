using Microsoft.Extensions.DependencyInjection;
using ResturantApplication.Application.Service;
namespace ResturantApplication.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRoomService,RoomService>();
    }
}

