using AutoMapper;
using CaseStudy6_Company_Revission.DTOs.ApplicationUserDTO;
using CaseStudy6_Company_Revission.UoW.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy6_Company_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var res = await _unitOfWork.authRepo.Register(dto);

            if (!res)
            {
                return BadRequest("Username already exists OR Password not equal confirm password");
            }

            return Ok("Registration successful");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var res = await _unitOfWork.authRepo.Login(dto);

            if (res == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(res);
        }
    }
}
