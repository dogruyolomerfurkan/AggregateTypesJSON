using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Entities;

namespace WebAPI.Context;

public class AppDbContext : DbContext
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=ExampleDb;Trusted_Connection=True;Encrypt=False");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
}
