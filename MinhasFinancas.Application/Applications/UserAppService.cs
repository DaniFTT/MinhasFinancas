using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Application.ViewModels.User;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Applications
{
    public class UserAppService : IUserAppService
    {
        protected readonly IMapper _mapper;
        protected readonly IUserService _userService;

        public UserAppService(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Login(LoginViewModel login)
        {
            return await _userService.Login(login.UserEmail, login.UserSenha);
        }

        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            return await _userService.Register(register.UserEmail, register.UserSenha, register.UserFullname, register.UserAge);
        }
    }
}
