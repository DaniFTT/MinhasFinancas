using Microsoft.AspNetCore.Identity;
using MinhasFinancas.Application.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Response
{
    public class RolesResponse : BaseResponse
    {
        public IEnumerable<RoleSimpleModel>? Roles { get; set; }
        public RolesResponse(List<IdentityRole> identityRoles) : base(true)
        {
            Roles = identityRoles.Select(r => new RoleSimpleModel(r)).ToArray();
        }
        public RolesResponse(IList<string> rolesNames) : base(true)
        {
            Roles = rolesNames.Select(r => new RoleSimpleModel(r)).ToArray();
        }
        public RolesResponse() { }
        public RolesResponse(bool sucesso = true) : base(sucesso) { }
        public RolesResponse(string messase, bool sucesso = true) : base(messase, sucesso) { }
    }

    public class RoleSimpleModel
    {
        public string RoleName { get; set; }
        public string RoleNormalizedName { get; set; }

        public RoleSimpleModel(IdentityRole role)
        {
            RoleName = role.Name;
            RoleNormalizedName = role.NormalizedName;
        }

        public RoleSimpleModel(string roleName)
        {
            RoleName = roleName;
            RoleNormalizedName = roleName;
        }
    }
}
