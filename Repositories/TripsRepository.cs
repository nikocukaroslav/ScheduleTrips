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
        public async Task<IEnumerable<Image?>> GetImages()
        {
            return await scheduleTripsDbContext.Images.ToListAsync();
        }

        public async Task<Album?> GetSingleAsync(Guid id)
        {
            return await scheduleTripsDbContext.Album.Include(x=> x.Images).FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Album> EditAsync(Album album)
        {
            var editedAlbum = await scheduleTripsDbContext.Album.Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == album.Id);

            if (editedAlbum != null)
            {
                editedAlbum.Id = album.Id;
                editedAlbum.Name = album.Name;
                
                await scheduleTripsDbContext.SaveChangesAsync();
                return editedAlbum;
            }

            return null;
        }
        
        public async Task<Album?> DeleteAsync(Guid id)
        {
            var deletedAlbum = await scheduleTripsDbContext.Album.FindAsync(id);

            if (deletedAlbum != null)
            {
                scheduleTripsDbContext.Album.Remove(deletedAlbum);

                await scheduleTripsDbContext.SaveChangesAsync();
                return deletedAlbum;
            }

            return null;
        }

        public async Task<Image?> DeleteImage(Guid id)
        {
            var deletedImage = await scheduleTripsDbContext.Images.FindAsync(id);

            if (deletedImage != null)
            {
                scheduleTripsDbContext.Images.Remove(deletedImage);

                await scheduleTripsDbContext.SaveChangesAsync();
                return deletedImage;
            }

            return null;
        }
    }
}