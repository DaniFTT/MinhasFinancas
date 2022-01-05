using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.ViewModels.User
{
    public class LoginViewModel
    {
        public string UserEmail { get; set; } = string.Empty;
        public string UserSenha { get; set; } = string.Empty;
    }
}
