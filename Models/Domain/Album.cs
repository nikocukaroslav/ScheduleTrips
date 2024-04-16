using System.ComponentModel.DataAnnotations;

namespace Save__plan_your_trips.Models.Domain
{
    public class Album
    {
        public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        public List<Image>? Images { get; set; }
    }
}