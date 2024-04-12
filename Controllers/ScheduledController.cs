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
    public IActionResult ScheduledTrips()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddScheduledTrip()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddScheduledTrip(ScheduledTrip scheduledTrip,
        [FromBody] List<AddScheduledTripRequest> todoRequests)
    {
        if (ModelState.IsValid)
        {
            var newScheduledTrip = new ScheduledTrip
            {
                DateTime = scheduledTrip.DateTime,
                ToDo = new List<ToDo>(),
            };

            foreach (var todoRequest in todoRequests)
            {
                foreach (var toDo in todoRequest.ToDo)
                {
                    var newToDo = new ToDo
                    {
                        Task = toDo.Task,
                    };
                    await scheduledRepository.AddTodo(newToDo);
                }
            }

            await scheduledRepository.AddScheduledTrip(newScheduledTrip);
        }

        return RedirectToAction("ScheduledTrips");
    }
}