using Microsoft.AspNetCore.Mvc;

namespace Save__plan_your_trips.Controllers
{
    public class PreviewController : Controller
    {
        [RedirectToAuthenticatedUserHomePageAttribute]
        public IActionResult StarterPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
