using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Application.ViewModels.User
{
    public class TokenRequestViewModel
    {
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
