using FluentValidation;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Validators
{
    public class MovementValidator : AbstractValidator<Movement>
    {
        public MovementValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Por favor, preencha a Descrição do Movimento.")
                .NotNull().WithMessage("Por favor, preencha a Descrição do Movimento.")
                .MaximumLength(200).WithMessage("A Descrição do Movimento não pode ter mais que 200 caracteres.");

            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("Por favor, preencha o Valor do Movimento.")
                .NotNull().WithMessage("Por favor, preencha o Valor do Movimento.");

            RuleFor(c => c.Type)
                .NotEmpty().WithMessage("Por favor, selecione o Tipo do Movimento.")
                .NotNull().WithMessage("Por favor, selecione o Tipo do Movimento.");

            RuleFor(c => c.PaymentMethod)
                .NotEmpty().WithMessage("Por favor, selecione o Meio de Pagamento.")
                .NotNull().WithMessage("Por favor, selecione o Meio de Pagamento.");

            RuleFor(c => c.Category)
                .NotEmpty().WithMessage("Por favor, selecione a Categoria.")
                .NotNull().WithMessage("Por favor, selecione a Categoria.");

            RuleFor(c => c.DateOfMovement)
                .NotEmpty().WithMessage("Por favor, selecione a Data do Movimento.")
                .NotNull().WithMessage("Por favor, selecione a Data do Movimento.");

            RuleFor(c => c.User)
                .NotNull().WithMessage("Usuário não autenticado.");
        }
    }
}
