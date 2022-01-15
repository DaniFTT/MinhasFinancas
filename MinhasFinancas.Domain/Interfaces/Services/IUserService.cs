using Auth.Models;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IActionResult> Login(string email, string password);
        Task<IActionResult> Register(string email, string password, string fullName, int age);
        Task<AuthResult> VerifyAndGenerateToken(string token, string refreshToken);
        Task<string> GetUserId(string email);
        Task<ApplicationUser> GetUser(string email);
        string? GetIdLoggedUser();
    }
}
