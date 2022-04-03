using MinhasFinancas.Application.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Response
{
    public class RemoveUserFromRoleResponse : BaseResponse
    {
        public RemoveUserFromRoleResponse() { }
        public RemoveUserFromRoleResponse(bool sucesso = true) : base(sucesso) { }
        public RemoveUserFromRoleResponse(string message, bool sucesso = true) : base(message, sucesso) { }
    }
}
