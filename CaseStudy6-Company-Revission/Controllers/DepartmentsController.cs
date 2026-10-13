using AutoMapper;
using CaseStudy6_Company_Revission.DTOs.DepartmentDTO;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.UoW.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy6_Company_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public DepartmentsController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddDepartmentDTO dto)
        {
            if (dto ==  null)
            {
                return BadRequest();
            }

            var res = new Department();

            res = _mapper.Map<Department>(dto);

            await _unitOfWork.Departments.Add(res);

            await _unitOfWork.SaveAsync();

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.Departments.GetAll();

            var res = new List<GetDepartmentDTO>();

            res = _mapper.Map<List<GetDepartmentDTO>>(departments);

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
            var department = await _unitOfWork.Departments.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            var res = new GetDepartmentDTO
            {
                Id = id,
                Name = department.Name,
                Location = department.Location,
            };

            return Ok(res);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int id , AddDepartmentDTO dto)
        {
            var d = await _unitOfWork.Departments.GetById(id);

            if (d == null)
            {
                return NotFound();
            }

            d = _mapper.Map(dto , d);

            _unitOfWork.Departments.Update(d);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var d = await _unitOfWork.Departments.GetById(id);

            if (d == null)
            {
                return NotFound();
            }

            _unitOfWork.Departments.Delete(d);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
