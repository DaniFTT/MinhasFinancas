using MinhasFinancas.Application.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Response
{
    public class AddUserToClaimsResponse : BaseResponse
    {
        public AddUserToClaimsResponse(bool sucesso = true) : base(sucesso) { }
        public AddUserToClaimsResponse(string message, bool sucesso = true) : base(message, sucesso) { }
    }
}
