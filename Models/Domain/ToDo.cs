namespace Save__plan_your_trips.Models.Domain;

public class ToDo
{
    public Guid Id { get; set; }
    
    public string Task { get; set; }
    
    public ScheduledTrip ScheduledTrip { get; set; }
}