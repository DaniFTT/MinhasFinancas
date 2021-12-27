using FluentValidation;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Validators
{
    public class WalletValidator : AbstractValidator<Wallet>
    {
        public WalletValidator()
        {
            RuleFor(c => c.User)
                .NotNull().WithMessage("Usuário não autenticado.");
        }
    }
}
