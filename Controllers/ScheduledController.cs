using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Models.Domain;
using Save__plan_your_trips.Models.ViewModels;
using Save__plan_your_trips.Repositories;

namespace Save__plan_your_trips.Controllers;

public class ScheduledController : Controller
{
    private ScheduledRepository? scheduledRepository;

    public ScheduledController(IScheduledRepository scheduledRepository)
    {
        this.scheduledRepository = (ScheduledRepository?)scheduledRepository;
    }

    [HttpGet]
    public async Task<IActionResult>  ScheduledTrips()
    {
        var scheduledTrips = await scheduledRepository.GetAllAsync();
        return View(scheduledTrips);
    }

    [HttpGet]
    public IActionResult AddScheduledTrip()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddScheduledTrip(AddScheduledTripRequest addScheduledTripRequest)
    {
        {
            if (ModelState.IsValid)
            {
                var newScheduledTrip = new ScheduledTrip
                {
                    Name = addScheduledTripRequest.Name,
                    First = addScheduledTripRequest.First,
                    Second = addScheduledTripRequest.Second,
                    Third = addScheduledTripRequest.Third,
                    Fourth = addScheduledTripRequest.Fourth,
                    Fifth = addScheduledTripRequest.Fifth,
                    DateTime = addScheduledTripRequest.DateTime,
                };

                await scheduledRepository.AddScheduledTrip(newScheduledTrip);
            }

            return RedirectToAction("ScheduledTrips");
        }
    }
}