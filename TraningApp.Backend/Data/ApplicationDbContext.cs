using Microsoft.EntityFrameworkCore;
using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    
    public ApplicationDbContext(DbContextOptions options): base(options)
    {

    }
}
