using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file);
        Task<IEnumerable<Album?>> GetAll();
    }
}
