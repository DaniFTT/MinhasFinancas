using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Models
{
    public class AuthResult
    {
        public string Token { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public List<string> Errors { get; set; }
    }
}
