using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ResturantApplication.Application.Service;
namespace ResturantApplication.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRoomService,RoomService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly).AddFluentValidationAutoValidation();
    }
}

