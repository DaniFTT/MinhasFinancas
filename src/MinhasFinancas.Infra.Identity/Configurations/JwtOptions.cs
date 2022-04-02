using Microsoft.IdentityModel.Tokens;

namespace MinhasFinancas.Infra.Identity.Configurations
{
    public class JwtOptions
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public SigningCredentials? SigningCredentials { get; set; }
        public int ExpirationHours { get; set; }
    }
}
