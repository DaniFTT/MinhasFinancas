using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Request;
using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Response;

namespace MinhasFinancas.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<UserLoginResponse> Login(UserLoginRequest login);
        Task<UserRegisterResponse> Register(UserRegisterRequest register);
    }
}
