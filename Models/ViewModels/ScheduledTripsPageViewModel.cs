using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class ScheduledTripsPageViewModel
{
    public IEnumerable<ScheduledTrip> ScheduledTrips { get; set; }
    public List<ToDo> ToDos { get; set; }
    public List<PerformToDoRequest>  PerformToDoRequests { get; set; }
}