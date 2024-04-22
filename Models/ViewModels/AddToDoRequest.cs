using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class AddToDoRequest
{
    public string Task { get; set; }
    public Guid ScheduledTripId { get; set; }
}