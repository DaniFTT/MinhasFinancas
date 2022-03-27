using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.ViewModels.User;
using MinhasFinancas.Infra.AuthConfig.Models;

namespace MinhasFinancas.Application.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<IActionResult> Login(LoginViewModel login);
        Task<IActionResult> Register(RegisterViewModel register);
        Task<AuthResult> RefreshToken(TokenRequestViewModel tokenRequest);
    }
}
