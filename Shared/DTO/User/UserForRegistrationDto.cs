using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.User
{
    public class UserForRegistrationDto
    {
        // re
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
