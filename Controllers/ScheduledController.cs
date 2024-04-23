using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public IActionResult AddScheduledTripName()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddScheduledTripName(AddScheduledTripRequest addScheduledTripRequest)
    {
        var scheduledTrip = new ScheduledTrip
        {
            Name = addScheduledTripRequest.Name,
            DateTime = DateTime.Now,
        };

        if (scheduledTrip != null)
        {
            await scheduledRepository.AddScheduledTrip(scheduledTrip);
            return RedirectToAction("AddScheduledTrip", new { id = scheduledTrip.Id });
        }

        return RedirectToAction("AddScheduledTripName");
    }

    [HttpGet]
    public async Task<IActionResult> AddScheduledTrip(Guid id)
    {
        var scheduledTrip = await scheduledRepository.GetSingleAsync(id);
        
            var model = new AddScheduledTripViewModel
            {
                ScheduledTrip = scheduledTrip,
                ToDoList = scheduledTrip?.ToDos,
            };

            return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddScheduledTrip(Guid id, AddScheduledTripRequest addScheduledTripRequest)
    {
        if (ModelState.IsValid)
        {
            var scheduledTrip = await scheduledRepository.GetSingleAsync(id);

            scheduledTrip.DateTime = addScheduledTripRequest.DateTime;
            await scheduledRepository.AddScheduledTrip(scheduledTrip);
        }

        return RedirectToAction("ScheduledTrips");
    }

    [HttpPost]
    public async Task<IActionResult> AddToDo(AddToDoRequest addToDoRequest)
    {
        if (ModelState.IsValid)
        {
            var todo = new ToDo
            {
                Task = addToDoRequest.Task,
                ScheduledTripId = addToDoRequest.ScheduledTripId,
            };

            await scheduledRepository.AddToDo(todo);
        }

        return RedirectToAction("AddScheduledTrip", new { id = addToDoRequest.ScheduledTripId });
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
            DateTime = editScheduledTripRequest.DateTime,
        };

        var result = await scheduledRepository.EditScheduledTrip(editedScheduledTrip);
        if (result != null)
            return RedirectToAction("ScheduledTrips");
        return RedirectToAction("ScheduledTrips");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteScheduledTrip(EditScheduledTripRequest editScheduledTripRequest)
    {
        var deletedScheduledTrip = await scheduledRepository.DeleteScheduledTrip(editScheduledTripRequest.Id);
        if (deletedScheduledTrip != null)
            return RedirectToAction("ScheduledTrips");
        return RedirectToAction("EditScheduledTrip", new { id = editScheduledTripRequest.Id });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteToDo(DeleteToDoRequest deleteToDoRequest)
    {
        var deletedToDo = await scheduledRepository.DeleteToDo(deleteToDoRequest.Id);
        if (deletedToDo != null)
            return RedirectToAction("AddScheduledTrip", new { id = deleteToDoRequest.ScheduledTripId });
        return NotFound();
    }
}