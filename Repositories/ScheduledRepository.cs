using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Save__plan_your_trips.Data;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories;

public class ScheduledRepository : IScheduledRepository
{
    private ScheduleTripsDbContext scheduleTripsDbContext;

    public ScheduledRepository(ScheduleTripsDbContext scheduleTripsDbContext)
    {
        this.scheduleTripsDbContext = scheduleTripsDbContext;
    }

    public async Task<ScheduledTrip> AddScheduledTrip(ScheduledTrip scheduledTrip)
    {
        await scheduleTripsDbContext.ScheduledTrip.AddAsync(scheduledTrip);
        await scheduleTripsDbContext.SaveChangesAsync();
        return scheduledTrip;
    }

    public async Task<ToDo> AddToDo(ToDo todo)
    {
        await scheduleTripsDbContext.ToDos.AddAsync(todo);
        await scheduleTripsDbContext.SaveChangesAsync();
        return todo;
    }

    public async Task<IEnumerable<ToDo>> GetAllToDos()
    {
        return await scheduleTripsDbContext.ToDos.ToListAsync();
    }

    public async Task<ToDo> DeleteToDo(Guid id)
    {
        var deletedToDo = await scheduleTripsDbContext.ToDos.FindAsync(id);
        
        if (deletedToDo != null)
        {
            scheduleTripsDbContext.ToDos.Remove(deletedToDo);
            await scheduleTripsDbContext.SaveChangesAsync();
            return deletedToDo;
        }

        return null;
    }

    public async Task<IEnumerable<ScheduledTrip>> GetAllAsync()
    {
        return await scheduleTripsDbContext.ScheduledTrip.ToListAsync();
    }

    public async Task<ScheduledTrip?> GetSingleAsync(Guid id)
    {
        return await scheduleTripsDbContext.ScheduledTrip.Include(x => x.ToDos).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ScheduledTrip> EditScheduledTrip(ScheduledTrip scheduledTrip)
    {
        var editedScheduledTrip =
            await scheduleTripsDbContext.ScheduledTrip.FirstOrDefaultAsync(x => x.Id == scheduledTrip.Id);

        if (editedScheduledTrip != null)
        {
            editedScheduledTrip.Name = scheduledTrip.Name;

            editedScheduledTrip.DateTime = scheduledTrip.DateTime;
        }

        if (editedScheduledTrip != null)
        {
            await scheduleTripsDbContext.SaveChangesAsync();
            return editedScheduledTrip;
        }

        return null;
    }

    public async Task<ScheduledTrip> DeleteScheduledTrip(Guid id)
    {
        var deletedScheduledTrip = await scheduleTripsDbContext.ScheduledTrip.FindAsync(id);

        if (deletedScheduledTrip != null)
        {
            scheduleTripsDbContext.ScheduledTrip.Remove(deletedScheduledTrip);
            await scheduleTripsDbContext.SaveChangesAsync();
            return deletedScheduledTrip;
        }

        return null;
    }
}