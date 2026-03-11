using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
namespace ResturantApplication.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c=>c.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
        services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly).AddFluentValidationAutoValidation();
    }
}

