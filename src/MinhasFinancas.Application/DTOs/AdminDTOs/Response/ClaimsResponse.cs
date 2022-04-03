using MinhasFinancas.Application.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.DTOs.AdminDTOs.Response
{
    public class ClaimsResponse : BaseResponse
    {
        public IEnumerable<ClaimsSimpleModel>? Claims { get; set; }
        public ClaimsResponse(IList<Claim> claimsIdentity) : base(true)
        {
            Claims = claimsIdentity.Select(c => new ClaimsSimpleModel(c)).ToArray();
        }
        public ClaimsResponse() { }
        public ClaimsResponse(bool sucesso = true) : base(sucesso) { }
        public ClaimsResponse(string messase, bool sucesso = true) : base(messase, sucesso) { }
    }

    public class ClaimsSimpleModel
    {
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }

        public ClaimsSimpleModel(Claim claim)
        {
            ClaimName = claim.Type;
            ClaimValue = claim.Value;
        }
    }
}
