﻿using Azure.Core;
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

    public async Task<ScheduledTrip?> GetSingleAsync(Guid id)
    {
        return await scheduleTripsDbContext.ScheduledTrip.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ScheduledTrip> EditScheduledTrip(ScheduledTrip scheduledTrip)
    {
        var editedScheduledTrip =
            await scheduleTripsDbContext.ScheduledTrip.FirstOrDefaultAsync(x => x.Id == scheduledTrip.Id);

        if (editedScheduledTrip != null)
        {
            editedScheduledTrip.Name = scheduledTrip.Name;
            editedScheduledTrip.First = scheduledTrip.First;
            editedScheduledTrip.Second = scheduledTrip.Second;
            editedScheduledTrip.Third = scheduledTrip.Third;
            editedScheduledTrip.Fourth = scheduledTrip.Fourth;
            editedScheduledTrip.Fifth = scheduledTrip.Fifth;
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