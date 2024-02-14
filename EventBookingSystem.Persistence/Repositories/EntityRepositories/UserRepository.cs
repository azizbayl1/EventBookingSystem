using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;
using EventBookingSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingSystem.Persistence.Repositories.EntityRepositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    
}
