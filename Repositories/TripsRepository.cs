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
            return await scheduleTripsDbContext.Album.Include(a => a.Images).ToListAsync();
        }


        public async Task<Album> AddAsync(Album album)
        {
            await scheduleTripsDbContext.Album.AddAsync(album);
            await scheduleTripsDbContext.SaveChangesAsync();
            return album;
        }

        public async Task<Image> AddAsync(Image image)
        {
            await scheduleTripsDbContext.Images.AddAsync(image);
            await scheduleTripsDbContext.SaveChangesAsync();
            return image;
        }
    }
}
