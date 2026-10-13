using AutoMapper;
using CaseStudy6_Company_Revission.DTOs.EmployeeProjectDTO;
using CaseStudy6_Company_Revission.DTOs.ProjectsDTO;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.UoW.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy6_Company_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectsController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public EmployeeProjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddEmployeeProjectDTO dto)
        {
            if (dto ==  null)
            {
                return BadRequest();
            }

            var existingEmplyee = await _unitOfWork.Employees.GetById(dto.EmployeeId);

            var existingProject = await _unitOfWork.Projects.GetById(dto.ProjectId);

            if (existingEmplyee == null)
            {
                return BadRequest("Employee not found");
            } 

            if (existingProject == null)
            {
                return BadRequest("project not found");
            }

            var res = new EmployeeProject();

            res = _mapper.Map<EmployeeProject>(dto);

            await _unitOfWork.EmployeeProjects.Add(res);

            await _unitOfWork.SaveAsync();

            return Created();
        }

        [HttpGet("Search-ByEmployeeId")]
        public async Task<IActionResult> Get(int employeeId)
        {
            var res = await _unitOfWork.EmployeeProjects
                .GetByEmployeeId(employeeId);

            var e = new GetEmployeeProjectDTO();

            e = _mapper.Map<GetEmployeeProjectDTO>(res);

            return Ok(e);
        }
    }
}
