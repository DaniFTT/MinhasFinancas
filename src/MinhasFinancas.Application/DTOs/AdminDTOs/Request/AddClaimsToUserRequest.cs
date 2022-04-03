using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Request
{
    public class AddClaimsToUserRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome da Função")]
        public string ClaimName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Valor da Função")]
        public string ClaimValue { get; set; } = string.Empty;
    }
}
