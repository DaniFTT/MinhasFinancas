using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;
using MinhasFinancas.Infra.CrossCutting.Auth.Services;
using System.Security.Claims;
using System.Text;


namespace MinhasFinancas.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return new BadRequestObjectResult("Erro: Login ou senha não foram preenchidos");

            var result = await
                _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var userId = await GetUserId(email);
                var tokenString = TokenService.GenerateToken(userId, email);

                return new OkObjectResult(tokenString);
            }
            else
            {
                return new BadRequestObjectResult("Erro: Login ou senha incorretos");
            }
        }

        public async Task<IActionResult> Register(string email, string password, string fullName, int age)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName) || age <= 0)
                return new BadRequestObjectResult("Faltam alguns dados!");

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                UserFullname = email,
                UserAge = age,
                UserType = Enums.UserType.Common
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Errors.Any())
                return new BadRequestObjectResult(result.Errors);

            //Geração de Confirmação caso precise
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //Retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultConfirmationEmail = await _userManager.ConfirmEmailAsync(user, code);

            if (resultConfirmationEmail.Succeeded)
                return new OkObjectResult("Usuário Adicionado com Sucesso!");
            else
                return new BadRequestObjectResult("Erro ao confirmar usuário!");
        }

        public Task<List<ApplicationUser>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetUserId(string email)
        {
            var userId = await _userRepository.GetUserId(email);
            return userId;
        }

        public async Task<ApplicationUser> GetUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
    }
}
