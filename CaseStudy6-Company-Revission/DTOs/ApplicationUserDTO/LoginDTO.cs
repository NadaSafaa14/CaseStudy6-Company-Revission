using System.ComponentModel.DataAnnotations;

namespace CaseStudy6_Company_Revission.DTOs.ApplicationUserDTO
{
    public class LoginDTO
    {
       

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

    

    }
}
