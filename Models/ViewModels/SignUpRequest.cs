using System.ComponentModel.DataAnnotations;

namespace Save__plan_your_trips.Models.ViewModels
{
    public class SignUpRequest
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password has to be at least 6 characters")]
        public string Password { get; set; }
    }
}
