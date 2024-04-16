using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

            if (addAlbumRequest.Images?.File != null)
                foreach (var imageRequest in addAlbumRequest.Images.File)
                {
                    var image = new Image
                    {
                        AlbumId = album.Id,
                    };
                    await tripsRepository.AddAsync(image, imageRequest);
                }

            return RedirectToAction("YourAlbums");
        }

        [HttpGet]
        public async Task<IActionResult> EditAlbum(Guid id)
        {
            var album = await tripsRepository.GetSingleAsync(id);
            if (album != null)
            {
                var model = new EditAlbumRequest
                {
                    Id = album.Id,
                    Name = album.Name,
                    Images = new List<Image>(),
                    ImageUrls = string.Join("\n\n", album.Images.Select(i => i.Url)),
                };
                foreach (var image in album.Images)
                {
                    var existingImage = new Image { Url = image.Url };
                    model.Images.Add(existingImage);
                }

                return View(model);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> EditAlbum(EditAlbumRequest editAlbumRequest)
        {
            var editedAlbum = new Album
            {
                Id = editAlbumRequest.Id,
                Name = editAlbumRequest.Name,
            };
            foreach (var imageRequest in editAlbumRequest.AddImageRequest.File)
            {
                var image = new Image
                {
                    AlbumId = editAlbumRequest.Id,
                    Url = editAlbumRequest.ImageUrls,
                };
                await tripsRepository.AddAsync(image, imageRequest);
            }

            var result = await tripsRepository.EditAsync(editedAlbum);
            if (result != null)
                return RedirectToAction("YourAlbums");
            return RedirectToAction("EditAlbum");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAlbum(EditAlbumRequest editAlbumRequest)
        {
            var deletedAlbum = await tripsRepository.DeleteAsync(editAlbumRequest.Id);

            if (deletedAlbum != null)
                return RedirectToAction("YourAlbums");
            return RedirectToAction("EditAlbum", new { id = editAlbumRequest.Id });
        }
    }
}