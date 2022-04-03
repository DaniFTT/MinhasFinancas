using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.DTOs.AdminDTOs.Request;
using MinhasFinancas.Application.DTOs.AdminDTOs.Response;
using MinhasFinancas.Application.Interfaces.Services;
using MinhasFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Identity.Services
{
    public class AdminSetupService : IAdminSetupService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminSetupService(UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<RolesResponse> GetAllRoles() 
        {
            try
            {
                return new RolesResponse(await _roleManager.Roles.ToListAsync());
            }
            catch (Exception)
            {
                return new RolesResponse();
            }
        }

        public async Task<AddUserToRoleResponse> AddUserToRole(AddUserToRoleRequest addUserToRoleRequest)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(addUserToRoleRequest.Email);
                if (user == null)
                    return new AddUserToRoleResponse("Usuário não Existe!", false);

                var roleExist = await _roleManager.RoleExistsAsync(addUserToRoleRequest.RoleName);
                if (!roleExist)
                    return new AddUserToRoleResponse("Role não Existe!", false);

                var result = await _userManager.AddToRoleAsync(user, addUserToRoleRequest.RoleName);

                if (result.Succeeded)
                    return new AddUserToRoleResponse($"Role adicionada ao {user.Email} com sucesso!");

                return new AddUserToRoleResponse($"Ocorreu um erro ao tentar adicionar essa Role ao {user.Email}!", false);

            }
            catch (Exception)
            {
                return new AddUserToRoleResponse();
            }
        }

        public async Task<CreateRoleResponse> CreateRole(string roleName)
        {
            try
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));

                    if (roleResult.Succeeded)
                        return new CreateRoleResponse("Role criada com Sucesso!");

                    return new CreateRoleResponse("Ocorreu um erro ao tentar adicionar essa Role!", false);
                }

                return new CreateRoleResponse("Essa Role já existe", false);

            }
            catch (Exception)
            {
                return new CreateRoleResponse();
            }
        }

        public async Task<UserResponse> GetAllUsers()
        {
            try
            {
                return new UserResponse(await _userManager.Users.ToListAsync());
            }
            catch (Exception)
            {
                return new UserResponse();
            }
        }

        public async Task<UserResponse> GetWithRole()
        {
            try
            {
                return new UserResponse(await _userManager.Users.ToListAsync());
            }
            catch (Exception)
            {
                return new UserResponse();
            }
        }

        public async Task<RolesResponse> GetUserRoles(string userEmail)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                    return new RolesResponse("Usuário não Existe!", false);

                return new RolesResponse(await _userManager.GetRolesAsync(user));
            }
            catch (Exception)
            {
                return new RolesResponse();
            }
        } 

        public async Task<RemoveUserFromRoleResponse> RemoveUserFromRole(RemoveUserFromRoleRequest removeUserFromRoleRequest)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(removeUserFromRoleRequest.Email);

                if (user == null)
                    return new RemoveUserFromRoleResponse("Usuário não Existe!", false);

                var roleExist = await _roleManager.RoleExistsAsync(removeUserFromRoleRequest.RoleName);
                if (!roleExist)
                    return new RemoveUserFromRoleResponse("Essa Role não existe!", false);

                var result = await _userManager.RemoveFromRoleAsync(user, removeUserFromRoleRequest.RoleName);
                if (result.Succeeded)
                    return new RemoveUserFromRoleResponse("Usuário removido da Role!", false);

                return new RemoveUserFromRoleResponse("Ocorreu um Erro na requisição!", false);
            }
            catch (Exception)
            {
                return new RemoveUserFromRoleResponse();
            }
        }

        public async Task<AddUserToClaimsResponse> AddClaimsToUser(AddClaimsToUserRequest addClaimsToUserRequest)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(addClaimsToUserRequest.Email);

                if (user == null)
                    return new AddUserToClaimsResponse("Usuário não Existe!", false);

                var userClaim = new Claim(addClaimsToUserRequest.ClaimName, addClaimsToUserRequest.ClaimValue);
                var result = await _userManager.AddClaimAsync(user, userClaim);

                if (result.Succeeded)
                    return new AddUserToClaimsResponse("Função adicionada ao Usuário com sucesso!");

                return new AddUserToClaimsResponse("Erro ao adicionar essa função para este usuário", false);
            }
            catch (Exception)
            {
                return new AddUserToClaimsResponse();
            }
        }

        public async Task<ClaimsResponse> GetAllClaims(string userEmail)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                    return new ClaimsResponse("Usuário não Existe!", false);

                return new ClaimsResponse(await _userManager.GetClaimsAsync(user));
            }
            catch (Exception)
            {
                return new ClaimsResponse();
            }
        }
    }
}
