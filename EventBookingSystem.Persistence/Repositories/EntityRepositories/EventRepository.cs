using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Persistence.Repositories.EntityRepositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
}
