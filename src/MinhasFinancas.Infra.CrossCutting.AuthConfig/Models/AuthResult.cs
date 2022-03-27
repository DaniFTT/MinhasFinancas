namespace MinhasFinancas.Infra.CrossCutting.AuthConfig.Models
{
    public class AuthResult
    {
        public string Token { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
