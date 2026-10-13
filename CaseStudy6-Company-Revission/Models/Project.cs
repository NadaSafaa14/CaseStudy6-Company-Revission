using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace CaseStudy6_Company_Revission.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required , MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required ,Range(1000 , 10000000)]
        public decimal Budget { get; set; }


        [Required]
        public int DepartmentId { get; set; }

        //[ForeignKey(nameof(Department))]
        public Department Department { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
