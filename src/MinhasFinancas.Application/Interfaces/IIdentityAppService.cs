using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Request;
using MinhasFinancas.Application.DTOs.AuthenticationDTOs.Response;

namespace MinhasFinancas.Application.Interfaces
{
    public interface IIdentityAppService
    {
        Task<UserLoginResponse> Login(UserLoginRequest login);
        Task<UserRegisterResponse> Register(UserRegisterRequest register);
    }
}
