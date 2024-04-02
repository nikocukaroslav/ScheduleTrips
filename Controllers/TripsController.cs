using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Models.Domain;
using Save__plan_your_trips.Models.ViewModels;
using Save__plan_your_trips.Repopositories;


namespace Save__plan_your_trips.Controllers
{
    [Authorize]
    public class TripsController : Controller
    {

        private readonly ITripsRepository tripsRepository;

        public TripsController(ITripsRepository tripsRepository)
        {
            this.tripsRepository = tripsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> YourAlbums()
        {
            var albums = await tripsRepository.GetAsync();

            return View(albums);
        }

        [HttpGet]
        [HttpPost]
        public async Task<ActionResult> AddAlbum(AddAlbumRequest addAlbumRequest)
        {
            if (!ModelState.IsValid) return View();

            var album = new Album
            {
                Name = addAlbumRequest.Name,
                Images = addAlbumRequest.ImageUrls.Select(url => new Image { Url = url }).ToList(),
            };

            foreach (var image in album.Images)
            {
                // Assuming AddAsync is a method to add image asynchronously
                await tripsRepository.AddAsync(image);
            }

            await tripsRepository.AddAsync(album);

            return RedirectToAction("YourAlbums");
        }
    }
}
