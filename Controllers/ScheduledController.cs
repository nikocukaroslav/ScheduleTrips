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
    public async Task<IActionResult> ScheduledTrips()
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

    [HttpGet]
    public async Task<IActionResult> EditScheduledTrip(Guid id)
    {
        var scheduledTrip = await scheduledRepository.GetSingleAsync(id);
        if (scheduledTrip == null) return View(null);
        var model = new EditScheduledTripRequest
        {
            Id = scheduledTrip.Id,
            Name = scheduledTrip.Name,
            First = scheduledTrip.First,
            Second = scheduledTrip.Second,
            Third = scheduledTrip.Third,
            Fourth = scheduledTrip.Fourth,
            Fifth = scheduledTrip.Fifth,
            DateTime = scheduledTrip.DateTime,
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditScheduledTrip(EditScheduledTripRequest editScheduledTripRequest)
    {
        var editedScheduledTrip = new ScheduledTrip
        {
            Id = editScheduledTripRequest.Id,
            Name = editScheduledTripRequest.Name,
            First = editScheduledTripRequest.First,
            Second = editScheduledTripRequest.Second,
            Third = editScheduledTripRequest.Third,
            Fourth = editScheduledTripRequest.Fourth,
            Fifth = editScheduledTripRequest.Fifth,
            DateTime = editScheduledTripRequest.DateTime,
        };

        var result = await scheduledRepository.EditScheduledTrip(editedScheduledTrip);
        if (result != null)
            return RedirectToAction("ScheduledTrips");
        return RedirectToAction("EditScheduledTrip");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteScheduledTrip(EditScheduledTripRequest editScheduledTripRequest)
    {
        var deletedAlbum = await scheduledRepository.DeleteScheduledTrip(editScheduledTripRequest.Id);
        if (deletedAlbum != null)
            return RedirectToAction("ScheduledTrips");
        return RedirectToAction("EditScheduledTrip",new { id = editScheduledTripRequest.Id });
    }
}