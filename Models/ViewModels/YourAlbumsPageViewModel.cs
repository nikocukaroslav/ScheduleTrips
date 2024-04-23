using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class YourAlbumsPageViewModel
{
    public IEnumerable<Album> Albums { get; set; }
    public DeleteImageRequest DeleteImageRequest { get; set; }
}