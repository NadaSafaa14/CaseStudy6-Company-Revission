using CaseStudy6_Company_Revission.Data;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.Repos.Interfaces;
using CaseStudy6_Company_Revission.UoW.Interface;

namespace CaseStudy6_Company_Revission.UoW.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;
        public IGenericRepo<Department> Departments { get; }

        public IEmployeeRepo Employees { get; }

        public IGenericRepo<Project> Projects { get; }
        public IEmployeeProjectRepo EmployeeProjects { get; }
        public IAuthRepo authRepo { get; }
        
        public UnitOfWork(AppDbContext context , IGenericRepo<Department> departments, IEmployeeRepo employees, IGenericRepo<Project> projects , IEmployeeProjectRepo employeeProjectRepo,IAuthRepo authRepo)
        {
            _context = context;
            Departments = departments;
            Employees=employees;
            Projects = projects;
            EmployeeProjects = employeeProjectRepo;
            this.authRepo = authRepo;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
