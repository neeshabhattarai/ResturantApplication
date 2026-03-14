using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Infastructure.Data;

public class ApplicationDbContext:IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Dish> Dish { get; set; }
}