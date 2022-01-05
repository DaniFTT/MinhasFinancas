using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<IActionResult> Login(LoginViewModel login);
        Task<IActionResult> Register(RegisterViewModel register);
    }
}
