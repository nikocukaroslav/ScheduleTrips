using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Models.Domain;
using Save__plan_your_trips.Models.ViewModels;
using Save__plan_your_trips.Repopositories;
using Save__plan_your_trips.Repositories;


namespace Save__plan_your_trips.Controllers
{
    public class TripsController : Controller
    {

        private readonly ITripsRepository tripsRepository;
        private readonly IImageRepository imageRepository;

        public TripsController(ITripsRepository tripsRepository, IImageRepository imageRepository)
        {
            this.tripsRepository = tripsRepository;
            this.imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> YourAlbums()
        {
            var photos = await imageRepository.GetAll();
            var places = await tripsRepository.GetAsync();

            return View(places);
        }

        [HttpGet]
        [HttpPost]
        public async Task<ActionResult> AddAlbum(AddAlbumRequest addAlbumRequest)
        {
            if (!ModelState.IsValid) return View(addAlbumRequest);
            var album = new Album
            {
                Name = addAlbumRequest.Name,
                Image = addAlbumRequest.Image
            };

            await tripsRepository.AddAsync(album);

            return RedirectToAction("YourAlbums");
        }
    }
}
