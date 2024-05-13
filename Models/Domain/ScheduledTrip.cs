using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Save__plan_your_trips.Models.Domain;

public class ScheduledTrip
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ToDo>? ToDos { get; set; }
    [Required] public DateTime DateTime { get; set; }
    public IdentityUser IdentityUser { get; set; }
}