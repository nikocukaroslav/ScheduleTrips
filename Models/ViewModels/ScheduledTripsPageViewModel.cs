using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class ScheduledTripsPageViewModel
{
    public IEnumerable<ScheduledTrip> ScheduledTrips { get; set; }
    public IEnumerable<ToDo> ToDos { get; set; }
}