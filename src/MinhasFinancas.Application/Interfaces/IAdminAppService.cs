using Microsoft.AspNetCore.Mvc;

namespace MinhasFinancas.Application.Interfaces
{
    public interface IAdminAppService
    {
        IActionResult GetAllRoles();
        Task<IActionResult> CreateRole(string name);
        Task<IActionResult> GetAllUsers();
        Task<IActionResult> AddUserToRole(string email, string roleName);
        Task<IActionResult> GetUserRoles(string email);
        Task<IActionResult> RemoveUserFromRole(string email, string roleName);
    }
}
