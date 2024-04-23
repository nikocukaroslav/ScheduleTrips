namespace Save__plan_your_trips.Models.ViewModels;

public class DeleteToDoRequest
{
    public Guid Id { get; set; }
    public Guid ScheduledTripId { get; set; }
}