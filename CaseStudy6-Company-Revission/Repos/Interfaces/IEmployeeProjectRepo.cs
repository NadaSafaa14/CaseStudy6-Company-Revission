using CaseStudy6_Company_Revission.DTOs.EmployeeProjectDTO;
using CaseStudy6_Company_Revission.Models;

namespace CaseStudy6_Company_Revission.Repos.Interfaces
{
    public interface IEmployeeProjectRepo : IGenericRepo<EmployeeProject>
    {
        Task<List<EmployeeProject>> GetByEmployeeId(int employeeId);
    }
}
