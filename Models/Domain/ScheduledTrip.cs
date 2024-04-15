namespace Save__plan_your_trips.Models.Domain;

public class ScheduledTrip
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string First { get; set; }
    public string Second { get; set; }
    public string Third { get; set; }
    public string Fourth { get; set; }
    public string Fifth { get; set; }
    public DateTime DateTime{ get; set; }
}