using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Enums
{
    public enum PaymentType
    {
        [Description("Dinheiro")]
        Cash = 0,
        [Description("Cartão de Débito")]
        DebitCard = 1,
    }
}
