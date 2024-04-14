using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories;

public interface IScheduledRepository
{
    Task<ScheduledTrip> AddScheduledTrip(ScheduledTrip scheduledTrip);
    Task<IEnumerable<ScheduledTrip>> GetAllAsync();
}