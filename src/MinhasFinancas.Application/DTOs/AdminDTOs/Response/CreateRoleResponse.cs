using MinhasFinancas.Application.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Response
{
    public class CreateRoleResponse : BaseResponse
    {
        public CreateRoleResponse() { }
        public CreateRoleResponse(bool sucesso = true) : base(sucesso) { }
        public CreateRoleResponse(string messase,bool sucesso = true) : base(messase, sucesso) { }
    }
}
