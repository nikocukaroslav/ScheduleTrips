using Microsoft.AspNetCore.Mvc;

namespace Save__plan_your_trips.Controllers
{
    public class PreviewController : Controller
    {
        public IActionResult StarterPage()
        {
            return View();
        }
    }
}
