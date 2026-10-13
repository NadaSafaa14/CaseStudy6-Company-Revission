using AutoMapper;
using CaseStudy6_Company_Revission.DTOs.DepartmentDTO;
using CaseStudy6_Company_Revission.DTOs.EmployeeDTO;
using CaseStudy6_Company_Revission.DTOs.EmployeeProjectDTO;
using CaseStudy6_Company_Revission.DTOs.ProjectsDTO;
using CaseStudy6_Company_Revission.Models;

namespace CaseStudy6_Company_Revission.Profiles
{
    public class GenericProfile : Profile
    {
        public GenericProfile()
        {
            CreateMap<AddDepartmentDTO, Department>();

            CreateMap<Department, GetDepartmentDTO>();
            
            CreateMap<AddEmployeeDTO, Employee>();

            CreateMap<Employee, GetEmployeeDTO>();
            
            CreateMap<AddProjectDTO, Project>();

            CreateMap<Project, GetProjectDTO>();
            
            CreateMap<AddEmployeeProjectDTO, EmployeeProject>();

            CreateMap<EmployeeProject, GetEmployeeProjectDTO>();
        }
    }
}
