namespace Save__plan_your_trips.Models
{
    public class Album
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string File { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
