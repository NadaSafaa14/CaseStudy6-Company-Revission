using CaseStudy6_Company_Revission.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy6_Company_Revission.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeProjects)
                .WithOne(p => p.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Project>()
               .HasMany(e => e.EmployeeProjects)
               .WithOne(p => p.Project)
               .HasForeignKey(e => e.ProjectId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
               .HasMany(e => e.Employees)
               .WithOne(p => p.Department)
               .HasForeignKey(e => e.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Department>()
               .HasMany(e => e.Projects)
               .WithOne(p => p.Department)
               .HasForeignKey(e => e.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeProject>()
                .HasIndex(e => new
                {
                    e.EmployeeId,
                    e.ProjectId,
                }).IsUnique();


            modelBuilder.Entity<Department>()
                .HasData(
                new Department
                {
                    Id = 1 ,
                    Name = "Department-1",
                    Location = "Cairo"
                });

            modelBuilder.Entity<Employee>()
                .HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Nada Safaa",
                    Email = "nada@example.com",
                    HireDate = new DateTime(2026 , 3 , 14),
                    Salary = 12000,
                    DepartmentId = 1
                });

            modelBuilder.Entity<Project>()
                .HasData(
                new Project
                {
                    Id = 1 ,
                    Name = "Project-1",
                    Budget = 10000,
                    DepartmentId = 1 ,
                    Description = null,
                    StartDate = new DateTime(2026 , 8 , 10),
                });

            modelBuilder.Entity<EmployeeProject>()
                .HasData(new EmployeeProject
                {
                    Id = 1,
                    AssignedDate = new DateTime(2026 , 9 , 12),
                    AssignedRole = "Role1",
                    EmployeeId = 1 ,
                    ProjectId = 1 
                });

        }
    }
}
