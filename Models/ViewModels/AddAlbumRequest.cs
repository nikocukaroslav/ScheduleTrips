using System.ComponentModel.DataAnnotations;

namespace Save__plan_your_trips.Models.ViewModels
{
    public class AddAlbumRequest
    {
        [Required] public AddPlaceRequest Place { get; set; }
        public AddImageRequest? Images { get; set; }
    }
}
