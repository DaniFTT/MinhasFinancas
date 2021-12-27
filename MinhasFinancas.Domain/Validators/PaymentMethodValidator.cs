using FluentValidation;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Validators
{
    public class PaymentMethodValidator : AbstractValidator<PaymentMethod>
    {
        public PaymentMethodValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, preencha o Nome do Meio de Pagamento.")
                .NotNull().WithMessage("Por favor, preencha o Nome do Meio de Pagamento.")
                .MaximumLength(100).WithMessage("O Nome do Meio de Pagamento não pode ter mais que 100 caracteres.");

            RuleFor(t => t.Name).Must((categoria, nome) =>
            {
                return true;
            }).When(t => !string.IsNullOrEmpty(t.Name)).WithMessage("Nome do plano de contas existente.");

            RuleFor(c => c.PaymentType)
                .NotEmpty().WithMessage("Por favor, preencha o Tipo do Meio de Pagamento.")
                .NotNull().WithMessage("Por favor, preencha o Tipo do Meio de Pagamento.");

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("Por favor, preencha o valor contido no Meio de Pagamento.")
                .NotNull().WithMessage("Por favor, preencha o valor contido no Meio de Pagamento.");

            RuleFor(c => c.Wallet)
                .NotNull().WithMessage("Você precisa criar uma Carteira para criar um meio de pagamento.");
        }
    }
}
