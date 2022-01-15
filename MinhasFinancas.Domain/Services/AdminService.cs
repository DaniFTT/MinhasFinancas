using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Services
{
    public class AdminService : IAdminService
    {
        public Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CreateRole(string name)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetUserRoles(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
