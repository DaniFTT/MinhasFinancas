using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Request;
using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Response;
using MinhasFinancas.Application.Interfaces.Services;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Infra.Identity.Configurations;
using MinhasFinancas.Infra.Identity.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MinhasFinancas.Infra.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                IHttpContextAccessor httpContextAccessor,
                                IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _jwtOptions = jwtOptions.Value;
        }
        public async Task<UserLoginResponse> Login(UserLoginRequest userLoginRequest)
        {
            UserLoginResponse usuarioLoginResponse;
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginRequest.Email, userLoginRequest.Password, false, true);
                if (result.Succeeded)
                    return await GenerateToken(userLoginRequest.Email);

                usuarioLoginResponse = new UserLoginResponse(result.Succeeded);
                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                        usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                    else if (result.IsNotAllowed)
                        usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                    else if (result.RequiresTwoFactor)
                        usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                    else
                        usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
                }

                return usuarioLoginResponse;
            }
            catch (Exception e)
            {
                usuarioLoginResponse = new UserLoginResponse();
                return usuarioLoginResponse;
            }
        }

        public async Task<UserRegisterResponse> Register(UserRegisterRequest userRegisterRequest)
        {
            UserRegisterResponse usuarioCadastroResponse;
            try
            {
                var user = new ApplicationUser
                {
                    UserName = userRegisterRequest.Email,
                    Email = userRegisterRequest.Email,
                    UserFullname = userRegisterRequest.Fullname,
                    UserAge = userRegisterRequest.Age,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, userRegisterRequest.Password);
                usuarioCadastroResponse = new UserRegisterResponse(result.Succeeded);

                if (result.Succeeded)
                {
                    var addRoleToUserResult = await _userManager.AddToRoleAsync(user, Roles.UserApp);

                    if (!addRoleToUserResult.Succeeded && addRoleToUserResult.Errors.Any())
                        usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

                    await _userManager.SetLockoutEnabledAsync(user, false);

                    return usuarioCadastroResponse;
                }

                if (!result.Succeeded && result.Errors.Any())
                    usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

                return usuarioCadastroResponse;
            }
            catch (Exception e)
            {
                usuarioCadastroResponse = new UserRegisterResponse();
                return usuarioCadastroResponse;
            }
        }

        private async Task<UserLoginResponse> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenClaims = await GetAllValidClaims(user);

            var dateExpiration = DateTime.Now.AddHours(_jwtOptions.ExpirationHours); ;
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dateExpiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new UserLoginResponse
            (
                success: true,
                token: token,
                dateExpiration: dateExpiration
            );
        }

        private async Task<IList<Claim>> GetAllValidClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in userRoles)
                claims.Add(new Claim("role", role));

            return claims;
        }

        public string GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var result = string.Empty;

            if (identity?.IsAuthenticated ?? false)
            {
                result = identity?.FindFirst("userId")?.Value;
            }

            return result ?? string.Empty;
        }
    }
}
