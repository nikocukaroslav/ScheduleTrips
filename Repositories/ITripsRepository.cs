using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories
{
    public interface ITripsRepository
    {
        Task<IEnumerable<Album>> GetAlbums();
        Task<Album?> GetAlbum();
        Task<ScheduledTrip?> GetScheduledTrip();
        Task <Album?> GetSingle(Guid id);
        Task<List<Image>> GetImages();
        Task<Album> AddAlbum(Album album);
        Task<Image> AddImage(Image image, IFormFile file);
        Task<Album?> DeleteAlbum(Guid id);
        Task<Image?> DeleteImage(Guid id);
        Task<Album> EditAlbum(Album album);
    }
}