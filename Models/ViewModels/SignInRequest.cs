using System.ComponentModel.DataAnnotations;

namespace Save__plan_your_trips.Models.ViewModels
{
    public class SignInRequest
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Invalid password")]
        public string Password { get; set; }
    }
}
