using MinhasFinancas.Application.DTOs.Shared;
using System.Text.Json.Serialization;

namespace MinhasFinancas.Application.DTOs.AuthenticationDTOs.Response
{
    public class UserLoginResponse : BaseResponse
    {
        public string? Token { get; private set; }

        public DateTime? DateExpiration { get; private set; }

        public UserLoginResponse() { }

        public UserLoginResponse(bool success = true) : base(success) { }

        public UserLoginResponse(string message, bool success = true) : base(message ,success) { }

        public UserLoginResponse(bool success, string token, DateTime dateExpiration) : this(success)
        {
            Token = token;
            DateExpiration = dateExpiration;
        }
    }
}
