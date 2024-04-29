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
            var albums = new YourAlbumsPageViewModel
            {
                Albums = await tripsRepository.GetAlbums(),
            };

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

            await tripsRepository.AddAlbum(album);

            if (addAlbumRequest.Images?.File != null)
                foreach (var imageRequest in addAlbumRequest.Images.File)
                {
                    var image = new Image
                    {
                        AlbumId = album.Id,
                    };
                    await tripsRepository.AddImage(image, imageRequest);
                }

            return RedirectToAction("YourAlbums");
        }

        [HttpGet]
        public async Task<IActionResult> EditAlbum(Guid id)
        {
            var album = await tripsRepository.GetSingle(id);
            if (album == null) return View(null);
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

        [HttpPost]
        public async Task<IActionResult> EditAlbum(EditAlbumRequest editAlbumRequest)
        {
            var editedAlbum = new Album
            {
                Id = editAlbumRequest.Id,
                Name = editAlbumRequest.Name,
            };

            if (editAlbumRequest.AddImageRequest.File != null)
            {
                foreach (var imageRequest in editAlbumRequest.AddImageRequest.File)
                {
                    var image = new Image
                    {
                        AlbumId = editAlbumRequest.Id,
                        Url = editAlbumRequest.ImageUrls,
                    };
                    await tripsRepository.AddImage(image, imageRequest);
                }
            }

            var result = await tripsRepository.EditAlbum(editedAlbum);
            if (result != null)
                return RedirectToAction("YourAlbums");
            return RedirectToAction("EditAlbum");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAlbum(EditAlbumRequest editAlbumRequest)
        {
            var deletedAlbum = await tripsRepository.DeleteAlbum(editAlbumRequest.Id);

            if (deletedAlbum != null)
                return RedirectToAction("YourAlbums");
            return RedirectToAction("EditAlbum", new { id = editAlbumRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(DeleteImageRequest deleteImageRequest)
        {
            await tripsRepository.DeleteImage(deleteImageRequest.Id);

            return RedirectToAction("YourAlbums");
        }
    }
}