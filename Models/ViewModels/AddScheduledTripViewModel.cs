using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class AddScheduledTripViewModel
{
    public AddScheduledTripNameRequest AddScheduledTripNameRequest { get; set; }
    public AddToDoRequest AddToDoRequest { get; set; }
    public AddScheduledTripDateRequest AddScheduledTripDateRequest { get; set; }
    public ScheduledTrip? ScheduledTrip { get; set; } = new();
    public List<ToDo>? ToDoList { get; set; }
    public DeleteToDoRequest DeleteToDoRequest { get; set; }
}