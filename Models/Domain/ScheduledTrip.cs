namespace Save__plan_your_trips.Models.Domain;

public class ScheduledTrip
{
    public Guid Id { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public List<ToDo> ToDo { get; set; }
}