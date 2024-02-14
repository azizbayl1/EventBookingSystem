using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Persistence.Context.SeedData;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Persistence.Context;

public class AppDbContext : DbContext
{
    //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //{
    //    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=EventBookingSystemDb;Integrated Security=True;TrustServerCertificate=True;");
    //    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    //}

    //public AppDbContext()
    //{
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=EventBookingSystem;Username=postgres;Password=Ps11");
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SpeakerEvent>().HasKey(src => new { src.SpeakerId, src.EventId });
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seeder();
    }
}
