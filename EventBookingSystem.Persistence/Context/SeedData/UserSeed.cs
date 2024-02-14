using EventBookingSystem.Domain.Entities;

namespace EventBookingSystem.Persistence.Context.SeedData
{
    public static partial class DataSeeder
    {
        public static List<User> SeedUser()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Aliyev",
                    Email = "ali@email.com",
                    Password = "pasS!2345",
                    RoleId = 1
                },

                new User()
                {
                    Id = 2,
                    FirstName = "Vali",
                    LastName = "Hasanli",
                    Email = "vali@email.com",
                    Password = "pasS!23456",
                    RoleId = 2
                },

                new User()
                {
                    Id = 3,
                    FirstName = "Nargiz",
                    LastName = "Hasanova",
                    Email = "hasanova@email.com",
                    Password = "pasS!23457",
                    RoleId = 3
                }
            };
            return users;
        }
    }
}
