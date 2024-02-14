using EventBookingSystem.Domain.Entities;

namespace EventBookingSystem.Persistence.Context.SeedData
{
    public static partial class DataSeeder
    {
        public static List<Category> SeedCategory()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Career Development"
                },
                new Category()
                {
                   Id = 2,
                   Name = "Social Activities"
                },
                new Category()
                {
                   Id = 3,
                   Name = "Study Abroad"
                },
                new Category()
                {
                   Id = 4,
                   Name = "Computer Science"
                },
                new Category()
                {
                   Id = 5,
                   Name = "Information Security"
                },
                new Category()
                {
                   Id = 6,
                   Name = "Artificial Intelligence"
                }
            };
            return categories;
        }
    }
}
