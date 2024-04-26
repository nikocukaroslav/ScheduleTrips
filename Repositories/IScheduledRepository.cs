using Save__plan_your_trips.Models.Domain;
using Save__plan_your_trips.Models.ViewModels;

namespace Save__plan_your_trips.Repositories;

public interface IScheduledRepository
{
    Task SaveChangesAsync();
    Task<ScheduledTrip> AddScheduledTrip(ScheduledTrip scheduledTrip);
    Task<ToDo> AddToDo(ToDo todo);
    Task<List<ToDo>> GetAllToDos();
    Task<ToDo?> DeleteToDo(Guid id);
    Task<ToDo?> GetSingleToDo(Guid id);
    Task<IEnumerable<ScheduledTrip>> GetAllAsync();
    Task<ScheduledTrip?> GetSingleAsync(Guid id);
    Task<ScheduledTrip?> DeleteScheduledTrip(Guid id);
    Task<ScheduledTrip?> EditScheduledTrip(ScheduledTrip scheduledTrip);
    Task<ScheduledTrip?> SubmitDate(ScheduledTrip scheduledTrip);
}