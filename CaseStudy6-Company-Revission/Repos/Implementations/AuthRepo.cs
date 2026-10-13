using CaseStudy6_Company_Revission.Data;
using CaseStudy6_Company_Revission.DTOs.ApplicationUserDTO;
using CaseStudy6_Company_Revission.Models;
using CaseStudy6_Company_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaseStudy6_Company_Revission.Repos.Implementations
{
    public class AuthRepo : IAuthRepo
    {
        protected readonly AppDbContext _context;
        protected readonly IConfiguration _config;
        public AuthRepo(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config=config;
        }
        public async Task<string?> Login(LoginDTO dto)
        {
            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
            {
                return null;
            }

            if (dto.Password != user.Password)
            {
                return null;
            }

            return GenerateToken(user);
        }

        public async Task<bool> Register(RegisterDTO dto)
        {
            var res = await _context.ApplicationUsers
                .AnyAsync(s => s.Email == dto.Email);

            if (res)
            {
                return false;
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                return false;
            }

            var user = new ApplicationUser
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role ?? "Member",
            };

            await _context.ApplicationUsers.AddAsync(user);

            await _context.SaveChangesAsync();

            return true;
        }

        private string GenerateToken(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:SecretKey"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier ,
                    user.Id.ToString()
                    ),

                new Claim(
                    ClaimTypes.Name ,
                    user.Name
                    ),

                new Claim(
                    ClaimTypes.Email ,
                    user.Email
                    ),

                new Claim(
                    ClaimTypes.Role ,
                    user.Role
                    ),
            };

            var TokenObj = new JwtSecurityToken
            (
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: Claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_config["JWT:ExpirationDurationInHours"]))
            );

            var Token = new JwtSecurityTokenHandler().WriteToken(TokenObj);

            return Token;
        }
    }
}
