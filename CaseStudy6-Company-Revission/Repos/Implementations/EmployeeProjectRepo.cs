using CaseStudy6_Company_Revission.Data;
using CaseStudy6_Company_Revission.DTOs.EmployeeProjectDTO;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy6_Company_Revission.Repos.Implementations
{
    public class EmployeeProjectRepo : GenericRepo<EmployeeProject>, IEmployeeProjectRepo
    {
        protected readonly AppDbContext _context;
        public EmployeeProjectRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EmployeeProject>> GetByEmployeeId(int employeeId)
        {
            var res = await _context.EmployeeProjects
                .Where(e => e.EmployeeId == employeeId)
                .ToListAsync();

            return res;
        }
    }
}
