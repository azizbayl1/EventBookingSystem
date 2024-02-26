using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Persistence.Context.SeedData;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Persistence.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Server=localhost;Port=5432;Database=EventBookingSystem;Username=postgres;Password=Ps11");
        options.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SpeakerEvent>().HasKey(src => new { src.SpeakerId, src.EventId });
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seeder();
    }

    //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //{
    //    options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=EventBookingSystemDb;Integrated Security=True;TrustServerCertificate=True;");
    //    options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    //}
}
