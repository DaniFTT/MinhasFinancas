﻿using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.DTOs.AdminDTOs.Request;
using MinhasFinancas.Application.DTOs.AdminDTOs.Response;

namespace MinhasFinancas.Application.Interfaces
{
    public interface IAdminAppService
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
