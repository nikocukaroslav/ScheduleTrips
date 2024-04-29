using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Save__plan_your_trips.Data;
using Save__plan_your_trips.Models.Domain;
using Save__plan_your_trips.Models.ViewModels;
using Save__plan_your_trips.Repositories;

namespace Save__plan_your_trips.Controllers;

public class ScheduledController : Controller
{
    private readonly ScheduledRepository? scheduledRepository;

    public ScheduledController(IScheduledRepository scheduledRepository)

    {
        this.scheduledRepository = (ScheduledRepository?)scheduledRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ScheduledTrips()
    {
        var scheduledTrips = (await scheduledRepository.GetAllScheduledTrips()).OrderBy(x => x.DateTime);
        var todos = await scheduledRepository.GetAllToDos();

        var plannedToDos = todos.Where(todo => !todo.IsPerformed).ToList();
        var performedToDos = todos.Where(todo => todo.IsPerformed).ToList();

        var scheduledTripsPageViewModel = new ScheduledTripsPageViewModel
        {
            ScheduledTrips = scheduledTrips,
            PlannedToDos = plannedToDos,
            PerformedToDos = performedToDos,
            ToDos = todos,
        };

        return View(scheduledTripsPageViewModel);
    }

    [HttpGet]
    public IActionResult AddScheduledTripName()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddScheduledTripName(AddScheduledTripNameRequest addScheduledTripNameRequest)
    {
        var scheduledTrip = new ScheduledTrip
        {
            Name = addScheduledTripNameRequest.Name,
        };

        if (ModelState.IsValid)
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

        if (scheduledTrip == null)
        {
            return NotFound();
        }

        var model = new AddScheduledTripViewModel
        {
            ScheduledTrip = scheduledTrip,
            ToDoList = scheduledTrip?.ToDos,
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddScheduledTripDate(AddScheduledTripDateRequest addScheduledTripDateRequest)
    {
        if (ModelState.IsValid)
        {
            var scheduledTripDateTime = new ScheduledTrip
            {
                Id = addScheduledTripDateRequest.Id,
                DateTime = addScheduledTripDateRequest.DateTime,
            };

            await scheduledRepository.SubmitDate(scheduledTripDateTime);
            return RedirectToAction("ScheduledTrips");
        }

        return NotFound();
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

        if (!string.IsNullOrEmpty(addToDoRequest.ReturnUrl))
        {
            return Redirect(addToDoRequest.ReturnUrl);
        }

        return RedirectToAction("AddScheduledTrip", new { id = addToDoRequest.ScheduledTripId });
    }

    [HttpPost]
    public async Task<IActionResult> PerformToDos(List<PerformToDoRequest> performToDoRequests)
    {
        foreach (var performToDoRequest in performToDoRequests)
        {
            var todo = await scheduledRepository.GetSingleToDo(performToDoRequest.Id);
            if (todo != null)
            {
                todo.IsPerformed = performToDoRequest.IsPerformed;
                await scheduledRepository.SaveChangesAsync();
            }
        }

        return RedirectToAction("ScheduledTrips");
    }
    
    [HttpPost]
    public async Task<IActionResult> UnperformToDos(List<UnperformToDoRequest> unperformToDoRequests)
    {
        foreach (var unperformToDoRequest in unperformToDoRequests)
        {
            var todo = await scheduledRepository.GetSingleToDo(unperformToDoRequest.Id);
            if (todo != null )
            {
                todo.IsPerformed = !unperformToDoRequest.IsPerformed;
                await scheduledRepository.SaveChangesAsync();
            }
        }

        return RedirectToAction("ScheduledTrips");
    }

    [HttpGet]
    public async Task<IActionResult> EditScheduledTrip(Guid id)
    {
        var scheduledTrip = await scheduledRepository.GetSingleAsync(id);
        if (scheduledTrip == null) return NotFound();
        var model = new AddScheduledTripViewModel
        {
            EditScheduledTripRequest = new EditScheduledTripRequest
            {
                Id = scheduledTrip.Id,
                Name = scheduledTrip.Name,
                DateTime = scheduledTrip.DateTime,
            },
            ScheduledTrip = scheduledTrip,
            ToDoList = scheduledTrip?.ToDos,
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

        await scheduledRepository.EditScheduledTrip(editedScheduledTrip);
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
        await scheduledRepository.DeleteToDo(deleteToDoRequest.Id);
        if (!string.IsNullOrEmpty(deleteToDoRequest.ReturnUrl))
        {
            return Redirect(deleteToDoRequest.ReturnUrl);
        }

        return NotFound();
    }
}