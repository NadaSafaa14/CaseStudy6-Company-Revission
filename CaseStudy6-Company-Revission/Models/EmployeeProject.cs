using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace CaseStudy6_Company_Revission.Models
{
    [Index(nameof(EmployeeId) ,nameof(ProjectId) , IsUnique = true)]
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }

        [Required , MaxLength(50)]
        public string AssignedRole { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        //[ForeignKey(nameof(Employee))]
        public Employee Employee { get; set; }

        [Required]
        public int ProjectId { get; set; }

        //[ForeignKey(nameof(Project))]
        public Project Project { get; set; }
    }
}
