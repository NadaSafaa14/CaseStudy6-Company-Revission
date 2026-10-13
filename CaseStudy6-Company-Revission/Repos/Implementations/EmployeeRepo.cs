using CaseStudy6_Company_Revission.Data;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy6_Company_Revission.Repos.Implementations
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        protected readonly AppDbContext _context;
        public EmployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetByDepartment(int DepartmentId)
        {
             var res = await _context.Employees
               .Where(e => e.DepartmentId == DepartmentId)
               .ToListAsync();

            return res;
        }

        public async Task<List<Employee>> SearchByName(string? name)
        {
            var res = await _context.Employees
                .Where(e => e.FullName.Contains(name))
                .ToListAsync(); 

            return res;
        }
    }
}
