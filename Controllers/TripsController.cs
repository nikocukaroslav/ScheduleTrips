using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Models.Domain;
using Save__plan_your_trips.Models.ViewModels;
using Save__plan_your_trips.Repositories;
using Image = Save__plan_your_trips.Models.Domain.Image;


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
                Name = addAlbumRequest.Place.Name,
            };

            await tripsRepository.AddAsync(album);

            foreach (var imageRequest in addAlbumRequest.Images)
            {
                var image = new Image
                {
                    AlbumId = album.Id,
                };
                await tripsRepository.AddAsync(image, imageRequest.File);
            }

            return RedirectToAction("YourAlbums");
        }
    }
}