using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.DTOs.AdminDTOs.Request;
using MinhasFinancas.Application.DTOs.AdminDTOs.Response;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.Interfaces.Services;
using MinhasFinancas.Domain.Interfaces.Services;

namespace MinhasFinancas.Application.Applications
{
    public class AdminAppService : IAdminAppService
    {
        protected readonly IAdminSetupService _adminService;

        public AdminAppService(IAdminSetupService adminService)
        {
            _adminService = adminService;
        }

        public async Task<RolesResponse> GetAllRoles()
        {
            return await _adminService.GetAllRoles();
        }

        public async Task<AddUserToRoleResponse> AddUserToRole(AddUserToRoleRequest addUserToRoleRequest)
        {
            return await _adminService.AddUserToRole(addUserToRoleRequest);
        }

        public async Task<CreateRoleResponse> CreateRole(string roleName)
        {
            return await _adminService.CreateRole(roleName);
        }

        public async Task<UserResponse> GetAllUsers()
        {
            return await _adminService.GetAllUsers();
        }

        public async Task<RolesResponse> GetUserRoles(string userEmail)
        {
            return await _adminService.GetUserRoles(userEmail);
        }

        public async Task<RemoveUserFromRoleResponse> RemoveUserFromRole(RemoveUserFromRoleRequest removeUserFromRoleRequest)
        {
            return await _adminService.RemoveUserFromRole(removeUserFromRoleRequest);
        }

        public async Task<AddUserToClaimsResponse> AddClaimsToUser(AddClaimsToUserRequest addClaimsToUserRequest)
        {
            return await _adminService.AddClaimsToUser(addClaimsToUserRequest);
        }

        public async Task<ClaimsResponse> GetAllClaims(string userEmail)
        {
            return await _adminService.GetAllClaims(userEmail);
        }
    }
}
