using System.ComponentModel.DataAnnotations;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class EditScheduledTripRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [Required] public DateTime DateTime { get; set; }
}