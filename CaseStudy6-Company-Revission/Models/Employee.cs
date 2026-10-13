using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace CaseStudy6_Company_Revission.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required , MaxLength(150)]
        public string FullName { get; set; }

        [Required , EmailAddress]
        public string Email { get; set; }

        [Required , Range(3000 , 100000)]
        public decimal Salary { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        //[ForeignKey(nameof(Department))]
        public Department Department { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();


    }
}
