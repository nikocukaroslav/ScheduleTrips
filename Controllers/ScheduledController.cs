using Microsoft.AspNetCore.Mvc;

namespace Save__plan_your_trips.Controllers;

public class ScheduledController : Controller
{
    // GET
    public IActionResult ScheduledTrips()
    {
        return View();
    }
}