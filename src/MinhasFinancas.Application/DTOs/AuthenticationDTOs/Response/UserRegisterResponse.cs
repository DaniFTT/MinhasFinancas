using MinhasFinancas.Application.DTOs.Shared;

namespace MinhasFinancas.Application.DTOs.AuthenticationDTOs.Response
{
    public class UserRegisterResponse : BaseResponse
    {
        public UserRegisterResponse() { }
        public UserRegisterResponse(bool sucesso = true) : base(sucesso) { }
        public UserRegisterResponse(string message, bool success = true) : base(message, success) { }
    }
}
