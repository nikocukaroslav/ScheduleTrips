using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories
{
    public interface ITripsRepository
    {
        Task<IEnumerable<Album?>> GetAsync();
        Task <Album?> GetSingleAsync(Guid id);
        
        Task<Album> AddAsync(Album album);
        
        Task<Image> AddAsync(Image image, IFormFile file);

        Task<Album?> DeleteAsync(Guid id);

        Task<Album> EditAsync(Album album);
    }
}