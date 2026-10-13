using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CaseStudy6_Company_Revission.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        [Required ,MinLength(20) , MaxLength(150)]
        public string Name { get; set; }

        [Required , MaxLength(100) , EmailAddress]
        public string Email { get; set; }

        [Required , MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(30)]
        public string Role { get; set; } = "Employee"; // Admin Or Employee = 

    }
}
