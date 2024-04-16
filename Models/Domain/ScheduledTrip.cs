using System.ComponentModel.DataAnnotations;

namespace Save__plan_your_trips.Models.Domain;

public class ScheduledTrip
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string First { get; set; }
    [Required] public string Second { get; set; }
    [Required] public string Third { get; set; }
    public string? Fourth { get; set; }
    public string? Fifth { get; set; }
    [Required] public DateTime DateTime { get; set; }
}