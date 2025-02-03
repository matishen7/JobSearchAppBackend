using System.Threading.Tasks;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;

public interface IAuthService
{
    Task<string> GenerateJwtToken(ApplicationUser user); // Generates a JWT Token for a user
    Task<(bool Succeeded, string Token, string ErrorMessage)> RegisterUser(RegisterDTO model);
    Task<(bool Succeeded, string Token, string ErrorMessage)> LoginUser(LoginDTO model);
}
