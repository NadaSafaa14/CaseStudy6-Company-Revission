using AutoMapper;
using CaseStudy6_Company_Revission.DTOs.DepartmentDTO;
using CaseStudy6_Company_Revission.DTOs.ProjectsDTO;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.UoW.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy6_Company_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public ProjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddProjectDTO dto)
        {
            if (dto ==  null)
            {
                return BadRequest();
            }

            var res = new Project();

            res = _mapper.Map<Project>(dto);

            await _unitOfWork.Projects.Add(res);

            await _unitOfWork.SaveAsync();

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var p = await _unitOfWork.Projects.GetAll();

            var res = new List<GetProjectDTO>();

            res = _mapper.Map<List<GetProjectDTO>>(p);

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
            var p = await _unitOfWork.Projects.GetById(id);

            if (p == null)
            {
                return NotFound();
            }

            var res = new GetProjectDTO
            {
                Id = id,
                Budget = p.Budget,
                DepartmentId = p.DepartmentId,
                Description = p.Description,
                Name = p.Name,
                StartDate = p.StartDate,
            };

            return Ok(res);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int id, AddProjectDTO dto)
        {
            var d = await _unitOfWork.Projects.GetById(id);

            if (d == null)
            {
                return NotFound();
            }

            d = _mapper.Map(dto, d);

            _unitOfWork.Projects.Update(d);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var d = await _unitOfWork.Projects.GetById(id);

            if (d == null)
            {
                return NotFound();
            }

            _unitOfWork.Projects.Delete(d);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
