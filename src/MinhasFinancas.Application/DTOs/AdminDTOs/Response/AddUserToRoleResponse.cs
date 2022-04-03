using MinhasFinancas.Application.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Response
{
    public class AddUserToRoleResponse : BaseResponse
    {
        public AddUserToRoleResponse() { }
        public AddUserToRoleResponse(bool sucesso = true) : base(sucesso) { }
        public AddUserToRoleResponse(string message,bool sucesso = true) : base(message, sucesso) { }
    }
}
