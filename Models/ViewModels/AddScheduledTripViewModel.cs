namespace Save__plan_your_trips.Models.ViewModels;

public class AddScheduledTripViewModel
{
    public AddScheduledTripRequest AddScheduledTripRequest { get; set; }
    public List<Domain.ScheduledTrip> ScheduledTrip { get; set; }
}