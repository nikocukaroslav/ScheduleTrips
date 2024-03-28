using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repopositories
{
    public interface ITripsRepository
    {
        Task<IEnumerable<Album?>> GetAsync();

        Task<Album> AddAsync(Album album);
    }
}
