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

    public async Task<ToDo> AddTodo(ToDo toDo)
    {
        await scheduleTripsDbContext.ToDo.AddAsync(toDo);
        await scheduleTripsDbContext.SaveChangesAsync();
        return toDo;
    }

    public Task<ToDo> DeleteToDo()
    {
        throw new NotImplementedException();
    }

    public async Task<List<ToDo>> GetAsync()
    {
        return await scheduleTripsDbContext.ToDo.ToListAsync();
    }
}