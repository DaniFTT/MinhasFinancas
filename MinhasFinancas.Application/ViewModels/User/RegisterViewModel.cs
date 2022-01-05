namespace MinhasFinancas.Application.ViewModels.User
{
    public class RegisterViewModel
    {
        public string UserFullname { get; set; } = string.Empty;
        public int UserAge { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string UserSenha { get; set; } = string.Empty;
    }
}
