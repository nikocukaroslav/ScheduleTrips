using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class AddScheduledTripRequest
{
    [Required] public string Name { get; set; }
    [Required] public DateTime DateTime { get; set; }
}