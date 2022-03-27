using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Application.ViewModels.User
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        public string UserSenha { get; set; } = string.Empty;
    }
}
