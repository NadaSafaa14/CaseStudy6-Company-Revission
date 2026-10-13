using System.ComponentModel.DataAnnotations;

namespace CaseStudy6_Company_Revission.DTOs.ApplicationUserDTO
{
    public class RegisterDTO
    {
        [Required, MinLength(20), MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [Required, MaxLength(30)]
        public string Role { get; set; } = "Employee"; // Admin Or Employee = 

    }
}
