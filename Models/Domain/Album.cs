namespace Save__plan_your_trips.Models.Domain
{
    public class Album
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public List<Image> Images { get; set; }

    }
}
