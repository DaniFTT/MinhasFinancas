using System.ComponentModel;

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
