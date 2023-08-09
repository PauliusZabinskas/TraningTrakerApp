using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TraningApp.Backend.Models;
using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> Users { get; set; }

    
    public ApplicationDbContext(DbContextOptions options): base(options)
    {

    }
}
