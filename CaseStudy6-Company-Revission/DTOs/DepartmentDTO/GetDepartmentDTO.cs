using System.ComponentModel.DataAnnotations;

namespace CaseStudy6_Company_Revission.DTOs.DepartmentDTO
{
    public class GetDepartmentDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }
    }
}
