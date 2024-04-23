namespace Save__plan_your_trips.Models.ViewModels;

public class DeleteImageRequest
{
    public Guid Id { get; set; }
    public Guid AlbumId { get; set; }
    public string? ReturnUrl { get; set; }
}