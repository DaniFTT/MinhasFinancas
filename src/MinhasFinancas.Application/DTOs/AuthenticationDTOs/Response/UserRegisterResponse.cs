using MinhasFinancas.Application.DTOs.Shared;

namespace MinhasFinancas.Application.DTOs.AuthenticationDTOs.Response
{
    public class UserRegisterResponse : BaseResponseDTO
    {
        public UserRegisterResponse() { }
        public UserRegisterResponse(bool sucesso = true) : base(sucesso) { }
    }
}
