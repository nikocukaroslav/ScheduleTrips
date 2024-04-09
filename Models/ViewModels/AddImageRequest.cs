namespace Save__plan_your_trips.Models.ViewModels
{
    public class AddImageRequest
    {
        public Guid AlbumId { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
