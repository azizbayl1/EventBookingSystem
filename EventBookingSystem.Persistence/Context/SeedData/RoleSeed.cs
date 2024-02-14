using EventBookingSystem.Domain.Entities;

namespace EventBookingSystem.Persistence.Context.SeedData
{
    public static partial class DataSeeder
    {
        public static List<Role> SeedRole()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                     Id = 1,
                     Name = "Admin"
                },

                new Role()
                {
                     Id = 2,
                     Name = "Manager"
                },

                new Role()
                {
                     Id = 3,
                     Name = "User"
                }
            };
            return roles;
        }
    }
}
