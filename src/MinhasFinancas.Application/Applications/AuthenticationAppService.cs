using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels.User;
using MinhasFinancas.Domain.Interfaces.Services;
using MinhasFinancas.Infra.AuthConfig.Models;

namespace MinhasFinancas.Application.Applications
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        protected readonly IMapper _mapper;
        protected readonly IAuthenticationService _userService;

        public AuthenticationAppService(IMapper mapper, IAuthenticationService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Login(LoginViewModel login)
        {
            return await _userService.Login(login.UserEmail, login.UserSenha);
        }

        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            return await _userService.Register(register.UserEmail, register.UserSenha, register.UserFullname, register.UserAge);
        }

        public async Task<AuthResult> RefreshToken(TokenRequestViewModel tokenRequest)
        {
            return await _userService.VerifyAndGenerateToken(tokenRequest.Token, tokenRequest.RefreshToken);
        }
    }
}
