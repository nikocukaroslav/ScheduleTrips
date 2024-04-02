namespace Save__plan_your_trips.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public Guid AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
