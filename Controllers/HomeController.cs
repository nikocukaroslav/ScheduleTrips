using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Models;
using System.Diagnostics;
using Save__plan_your_trips.Models.ViewModels;
using Save__plan_your_trips.Repositories;

namespace Save__plan_your_trips.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITripsRepository tripsRepository;

        public HomeController(ILogger<HomeController> logger,ITripsRepository tripsRepository)
        {
            _logger = logger;
            this.tripsRepository = tripsRepository;
        }
      
        public async Task<IActionResult> Index()
        {
            var images = new HomePageViewModel
            {
                Album = await tripsRepository.GetAlbum(),
                ScheduledTrip = await tripsRepository.GetScheduledTrip()
            };

            return View(images);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
