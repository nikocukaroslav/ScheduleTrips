using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories;

public interface IScheduledRepository
{
    Task<ScheduledTrip> AddScheduledTrip(ScheduledTrip scheduledTrip);
    Task<ToDo> AddToDo(ToDo todo);
    Task<IEnumerable<ToDo>> GetAllToDos();
    Task<IEnumerable<ScheduledTrip>> GetAllAsync();
    Task<ScheduledTrip?> GetSingleAsync(Guid id);
    Task<ScheduledTrip> DeleteScheduledTrip(Guid id);
    Task<ScheduledTrip> EditScheduledTrip(ScheduledTrip scheduledTrip);
}