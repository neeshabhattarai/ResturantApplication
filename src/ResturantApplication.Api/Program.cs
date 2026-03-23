using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestuarantApplication.Api.Extensions;
using ResturantApplication.Infastructure.Data;
using ResturantApplication.Application;
using ResturantApplication.Application.Extensions;
using ResturantApplication.Domain.Entities;
using ResturantApplication.Infastructure.DataSeed;
using ResturantApplication.Infastructure.Extensions;
using Serilog;
using Serilog.Events;using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddWebApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var scope=app.Services.CreateScope();
var seed=scope.ServiceProvider.GetRequiredService<IRoleSeed>();
await seed.Seed();
app.UseMiddleware(typeof(ExceptionHandler));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapGroup("/api").WithTags("User").MapIdentityApi<User>();
;
app.MapControllers();

app.Run();

public partial class Program
{
    
}
