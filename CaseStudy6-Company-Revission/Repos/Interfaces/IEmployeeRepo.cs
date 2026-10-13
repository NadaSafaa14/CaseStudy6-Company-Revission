using CaseStudy6_Company_Revission.Models;

namespace CaseStudy6_Company_Revission.Repos.Interfaces
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        Task<List<Employee>> SearchByName(string? name);
        Task<List<Employee>> GetByDepartment(int DepartmentId);
    }
}
