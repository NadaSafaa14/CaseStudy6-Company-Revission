using CaseStudy6_Company_Revission.Models;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy6_Company_Revission.DTOs.EmployeeProjectDTO
{
    public class AddEmployeeProjectDTO
    {
        [Required, MaxLength(50)]
        public string AssignedRole { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}
