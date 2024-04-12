using Microsoft.AspNetCore.Mvc;

namespace Save__plan_your_trips.Controllers;

public class ScheduledController : Controller
{
    [HttpGet]
    public IActionResult ScheduledTrips()
    {
        return View();
    }

    [HttpGet]
    [HttpPost]
    public IActionResult AddScheduledTrip()
    {
        return View();
    }
}