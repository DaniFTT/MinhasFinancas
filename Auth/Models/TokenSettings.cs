using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.CrossCutting.Auth.Models
{
    public static class TokenSettings
    {
        public static string TokenSecret = "Minhas_Financas-61403641";
        public static string Audience = "Minhas_Financas.Security.Bearer.Audience_61403641";
        public static string Issuer = "Minhas_Financas.Security.Bearer.Issuer_61403641";
    }
}
