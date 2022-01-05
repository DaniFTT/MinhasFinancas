using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IActionResult> Login(string email, string password);
        Task<IActionResult> Register(string email, string password, string fullName, int age);
        Task<List<ApplicationUser>> GetUsers();
        Task<string> GetUserId(string email);
        Task<ApplicationUser> GetUser(string email);
    }
}
