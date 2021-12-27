using FluentValidation;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, preencha o Nome da Categoria.")
                .NotNull().WithMessage("Por favor, preencha o Nome da Categoria.")
                .MaximumLength(100).WithMessage("O Nome da Categoria não pode ter mais que 100 caracteres");

            RuleFor(t => t.Name).Must((categoria, nome) =>
            {
                return true;
            }).When(t => !string.IsNullOrEmpty(t.Name)).WithMessage("Nome do plano de contas existente");

            RuleFor(c => c.Type)
                .NotEmpty().WithMessage("Por favor, preencha o Tipo da Categoria.")
                .NotNull().WithMessage("Por favor, preencha o Tipo da Categoria.");

            RuleFor(c => c.User)
                .NotNull().WithMessage("Usuário não autenticado.");
        }
    }

}
