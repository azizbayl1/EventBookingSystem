using EventBookingSystem.Domain.Entities;

namespace EventBookingSystem.Persistence.Context.SeedData
{
    public static partial class DataSeeder
    {
        public static List<Venue> SeedVenue()
        {
            var venues = new List<Venue>()
            {
                new Venue()
                {
                    Id = 1,
                    Name = "Event Hall",
                    Capacity = 400, 
                    RowCapacity = 16,
                }
                ,
                new Venue()
                {
                    Id = 2,
                    Name = "Room 201",
                    Capacity = 100,
                    RowCapacity = 10,
                },
                new Venue()
                {
                    Id = 3,
                    Name = "Room 506",
                    Capacity = 80,
                    RowCapacity = 10,
                }
            };
            return venues;
        }
    }
}
