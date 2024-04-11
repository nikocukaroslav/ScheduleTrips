namespace Save__plan_your_trips.Models.ViewModels;

public class AddToDoRequest
{
    public Guid ScheduleTripId { get; set; }
    
    public string Task { get; set; }
}