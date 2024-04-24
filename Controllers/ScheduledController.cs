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
        var todos = await scheduledRepository.GetAllToDos();

        var scheduledTripsPageViewModel = new ScheduledTripsPageViewModel
        {
            ScheduledTrips = scheduledTrips,
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
    public async Task<IActionResult> SortTodo(List<PerformToDoRequest> todos)
    {
        foreach (var todo in todos)
        {
            if (todo.IsPerformed)
            {
                var performedTodo = new ToDo
                {
                    Id = todo.Id,
                    IsPerformed = todo.IsPerformed,
                };
                await scheduledRepository.UpdateToDo(performedTodo);
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