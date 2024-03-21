using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Models.DbConnectModels;

namespace Save__plan_your_trips.Controllers
{
    public class TripsController : Controller
    {
        public IActionResult YourAlbums()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAlbum(AddAlbumRequest addAlbumRequest)
        {

            return View();
        }
    }
}
