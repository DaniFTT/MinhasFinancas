using System.ComponentModel;

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
