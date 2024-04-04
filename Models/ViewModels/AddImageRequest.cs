namespace Save__plan_your_trips.Models.ViewModels
{
    public class AddImageRequest
    {
        public Guid AlbumId { get; set; }
        public IFormFile File { get; set; }
    }
}
