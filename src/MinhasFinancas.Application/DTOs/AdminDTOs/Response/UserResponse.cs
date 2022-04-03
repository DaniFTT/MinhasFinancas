using MinhasFinancas.Application.DTOs.Shared;
using MinhasFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Response
{
    public class UserResponse : BaseResponse
    {
        public IEnumerable<UserSimpleModel>? Users { get; set; }
        public UserResponse(List<ApplicationUser> applicationUsers) : base(true)
        {
            Users = applicationUsers.Select(u => new UserSimpleModel(u)).ToArray();
        }
        public UserResponse() { }
        public UserResponse(bool sucesso = true) : base(sucesso) { }
        public UserResponse(string messase, bool sucesso = true) : base(messase, sucesso) { }
    }
    public class UserSimpleModel
    {
        public string NomeCompleto { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public UserSimpleModel(ApplicationUser user)
        {
            NomeCompleto = user.UserFullname;
            Email = user.Email;
            Age = user.UserAge;
        }
    }
}
