using EventBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Persistence.Context.SeedData
{
    public static partial class DataSeeder
    {
        public static void Seeder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(SeedCategory());
            modelBuilder.Entity<Role>().HasData(SeedRole());
            modelBuilder.Entity<User>().HasData(SeedUser());
            modelBuilder.Entity<Venue>().HasData(SeedVenue());
            
        }
    }
}
