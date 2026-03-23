using Microsoft.OpenApi.Models;
using ResturantApplication.Application.Extensions;
using ResturantApplication.Infastructure.DataSeed;
using ResturantApplication.Infastructure.Extensions;
using Serilog;

namespace RestuarantApplication.Api.Extensions;

public static class WebApplicationBuilderImplementation
{
    public static void AddWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IRoleSeed, RoleSeed>();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {{new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },[]}});
    

        });
        builder.Services.AddControllers();
        builder.Services.AddInfastructure(builder.Configuration);
        builder.Services.AddApplication();
        builder.Services.AddScoped<ExceptionHandler>();
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
            // configuration.WriteTo.File("Logs/logs-ResturantRoom-Api-.txt", rollingInterval: RollingInterval.Day,rollOnFileSizeLimit: true);
            // configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning).WriteTo.Console();
            // configuration.MinimumLevel.Override("Microsoft.EntityFramework", LogEventLevel.Information).WriteTo.File(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}");
        }); 
    }
}