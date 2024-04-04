namespace Save__plan_your_trips.Models.ViewModels
{
    public class AddAlbumRequest
    {
        public AddPlaceRequest Place { get; set; }

        public List<AddImageRequest> Images { get; set; }
    }
}
