using Microsoft.EntityFrameworkCore;
using RestuarantApplication.Api.Extensions;
using ResturantApplication.Infastructure.Data;
using ResturantApplication.Application;
using ResturantApplication.Application.Extensions;
using ResturantApplication.Infastructure.Extensions;
using Serilog;
using Serilog.Events;using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(ExceptionHandler));
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
