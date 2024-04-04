using Microsoft.EntityFrameworkCore;
using Save__plan_your_trips.Data;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories
{
    public class TripsRepository : ITripsRepository
    {

        private readonly ScheduleTripsDbContext scheduleTripsDbContext;
        private readonly ImageRepository imageRepository;

        public TripsRepository(ScheduleTripsDbContext scheduleTripsDbContext, IImageRepository imageRepository)
        {
            this.scheduleTripsDbContext = scheduleTripsDbContext;
            this.imageRepository = (ImageRepository)imageRepository;
        }

        public async Task<IEnumerable<Album?>> GetAsync()
        {
            return await scheduleTripsDbContext.Album.Include(a => a.Images).ToListAsync();
        }


        public async Task<Album> AddAsync(Album album)
        {
            await scheduleTripsDbContext.Album.AddAsync(album);
            await scheduleTripsDbContext.SaveChangesAsync();
            return album;
        }

        public async Task<Image> AddAsync(Image image, IFormFile file)
        {
            image.Url = await imageRepository.UploadAsync(file); 
            await scheduleTripsDbContext.Images.AddAsync(image);
            await scheduleTripsDbContext.SaveChangesAsync();
            return image;
        }

    }
}
