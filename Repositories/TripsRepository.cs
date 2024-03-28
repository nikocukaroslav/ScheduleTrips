using Microsoft.EntityFrameworkCore;
using Save__plan_your_trips.Data;
using Save__plan_your_trips.Models.Domain;


namespace Save__plan_your_trips.Repopositories
{
    public class TripsRepository : ITripsRepository
    {

        private readonly ScheduleTripsDbContext scheduleTripsDbContext;

        public TripsRepository(ScheduleTripsDbContext scheduleTripsDbContext)
        {
            this.scheduleTripsDbContext = scheduleTripsDbContext;
        }

        public async Task<IEnumerable<Album>> GetAsync()
        {
            return await scheduleTripsDbContext.Album.ToListAsync();
        }


        public async Task<Album> AddAsync(Album album)
        {
            await scheduleTripsDbContext.Album.AddAsync(album);
            await scheduleTripsDbContext.SaveChangesAsync();
            return album;
        }
    }
}
