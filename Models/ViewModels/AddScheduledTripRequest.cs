using System.Runtime.InteropServices.JavaScript;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Models.ViewModels;

public class AddScheduledTripRequest
{
    public Guid ScheduleTripId { get; set; }
    public List<ToDo> ToDo { get; set; }
    public DateTime DateTime { get; set; }
}