using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.DTOs.AdminDTOs.Request;
using MinhasFinancas.Application.DTOs.AdminDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interfaces.Services
{
    public interface IAdminSetupService
    {
        Task<RolesResponse> GetAllRoles();
        Task<CreateRoleResponse> CreateRole(string roleName);
        Task<UserResponse> GetAllUsers();
        Task<AddUserToRoleResponse> AddUserToRole(AddUserToRoleRequest addUserToRoleRequest);
        Task<RolesResponse> GetUserRoles(string userEmail);
        Task<RemoveUserFromRoleResponse> RemoveUserFromRole(RemoveUserFromRoleRequest removeUserFromRoleRequest);
        Task<ClaimsResponse> GetAllClaims(string userEmail);
        Task<AddUserToClaimsResponse> AddClaimsToUser(AddClaimsToUserRequest addClaimsToUserRequest);
    }
}
