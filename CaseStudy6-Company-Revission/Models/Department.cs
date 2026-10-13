using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace CaseStudy6_Company_Revission.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public ICollection<Project> Projects { get; set; } = new List<Project>();   
    }
}
