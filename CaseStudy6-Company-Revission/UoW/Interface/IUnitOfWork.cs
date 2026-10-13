using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.Repos.Interfaces;

namespace CaseStudy6_Company_Revission.UoW.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepo<Department> Departments { get; }
        IGenericRepo<Project> Projects { get; }
        IEmployeeRepo Employees { get; }
        IEmployeeProjectRepo EmployeeProjects { get; }
        IAuthRepo authRepo { get; }
        Task<int> SaveAsync();
    }
}
