using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Infra.AuthConfig.Models;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<IActionResult> Login(string email, string password);
        Task<IActionResult> Register(string email, string password, string fullName, int age);
        Task<AuthResult> VerifyAndGenerateToken(string token, string refreshToken);
        Task<string> GetUserId(string email);
        Task<ApplicationUser> GetUser(string email);
        string? GetIdLoggedUser();
    }
}
