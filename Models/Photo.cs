namespace Save__plan_your_trips.Models
{
    public class Photo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
