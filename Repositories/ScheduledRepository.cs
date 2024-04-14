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

    public async Task<IEnumerable<ScheduledTrip>> GetAllAsync()
    {
        return await scheduleTripsDbContext.ScheduledTrip.ToListAsync();
    }
}