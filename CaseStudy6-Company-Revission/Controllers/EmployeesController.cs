using AutoMapper;
using CaseStudy6_Company_Revission.DTOs.DepartmentDTO;
using CaseStudy6_Company_Revission.DTOs.EmployeeDTO;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.UoW.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy6_Company_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddEmployeeDTO dto)
        {
            if (dto ==  null)
            {
                return BadRequest();
            }

            var res = new Employee();

            res = _mapper.Map<Employee>(dto);

            await _unitOfWork.Employees.Add(res);

            await _unitOfWork.SaveAsync();

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var e = await _unitOfWork.Employees.GetAll();

            var res = new List<GetEmployeeDTO>();

            res = _mapper.Map<List<GetEmployeeDTO>>(e);

            //var res = new List<GetDepartmentDTO>();

            //foreach (var d in departments)
            //{
            //    res.Add(
            //        new GetDepartmentDTO
            //        {
            //            Id = d.Id,
            //            Name = d.Name,
            //            Location = d.Location,
            //        });
            //}

            if (res.Count == 0 || res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var e = await _unitOfWork.Employees.GetById(id);

            if (e == null)
            {
                return NotFound();
            }

            var res = new GetEmployeeDTO
            {
                Id = id,
                FullName = e.FullName,
                DepartmentId = e.DepartmentId,
                Email = e.Email,
                HireDate = e.HireDate,
                Salary = e.Salary,
            };

            return Ok(res);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int id, AddEmployeeDTO dto)
        {
            var d = await _unitOfWork.Employees.GetById(id);

            if (d == null)
            {
                return NotFound();
            }

            d = _mapper.Map(dto, d);

            _unitOfWork.Employees.Update(d);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var d = await _unitOfWork.Employees.GetById(id);

            if (d == null)
            {
                return NotFound();
            }

            _unitOfWork.Employees.Delete(d);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpGet("Search-Name")]
        public async Task<IActionResult> Search(string? name)
        {
            var res = await _unitOfWork.Employees.SearchByName(name);

            if (res == null || res.Count == 0)
            {
                return NotFound();
            }

            var e = new List<GetEmployeeDTO>();

            e = _mapper.Map<List<GetEmployeeDTO>>(res);

            return Ok(e);
        }

        [HttpGet("Get-ByDepartment")]
        public async Task<IActionResult> GetByDepartment(int DId)
        {
            var res = await _unitOfWork.Employees.GetByDepartment(DId);

            if (res == null || res.Count == 0)
            {
                return NotFound();
            }

            var e = new List<GetEmployeeDTO>();

            e = _mapper.Map<List<GetEmployeeDTO>>(res);

            return Ok(e);
        }
    }
}
