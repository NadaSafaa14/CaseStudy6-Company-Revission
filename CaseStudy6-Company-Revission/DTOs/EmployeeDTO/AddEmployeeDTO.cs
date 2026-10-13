using System.ComponentModel.DataAnnotations;

namespace CaseStudy6_Company_Revission.DTOs.EmployeeDTO
{
    public class AddEmployeeDTO
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Range(3000, 100000)]
        public decimal Salary { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
