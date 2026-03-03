using Microsoft.EntityFrameworkCore;
using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Infastructure.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<Room> Rooms { get; set; }
}