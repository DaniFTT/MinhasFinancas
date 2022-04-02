using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Request;
using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Response;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.Interfaces.Services;

namespace MinhasFinancas.Application.Applications
{
    public class IdentityAppService : IIdentityAppService
    {
        protected readonly IIdentityService _identityService;

        public IdentityAppService(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest login)
        {
            return await _identityService.Login(login);
        }

        public async Task<UserRegisterResponse> Register(UserRegisterRequest register)
        {
            return await _identityService.Register(register);
        }
    }
}
