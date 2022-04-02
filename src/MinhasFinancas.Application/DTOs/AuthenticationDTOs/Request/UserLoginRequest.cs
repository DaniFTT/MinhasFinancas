using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Application.DTOs.AuthenticationDTOs.Request
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; } = string.Empty;
    }
}
