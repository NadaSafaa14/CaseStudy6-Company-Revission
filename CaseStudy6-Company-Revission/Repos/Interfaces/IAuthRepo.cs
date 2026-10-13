using CaseStudy6_Company_Revission.DTOs.ApplicationUserDTO;

namespace CaseStudy6_Company_Revission.Repos.Interfaces
{
    public interface IAuthRepo
    {
        Task<bool> Register(RegisterDTO dto);

        Task<string?> Login(LoginDTO dto);
    }
}
