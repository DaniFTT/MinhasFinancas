using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Enums
{
    public enum UserType
    {
        [Description("Administrador")]
        Administrator = 1,
        [Description("Comum")]
        Common = 2
    }
}
