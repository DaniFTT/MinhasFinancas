using FluentValidation;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Validators
{
    public class UserValidator : AbstractValidator<ApplicationUser>
    {
        public UserValidator()
        {
            RuleFor(c => c.UserAge)
                .NotEmpty().WithMessage("Por favor, preencha a Idade.")
                .NotNull().WithMessage("Por favor, preencha a Idade.");

            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Por favor, preencha o email.")
                .NotNull().WithMessage("Por favor, preencha o email.");

            RuleFor(c => c.UserFullname)
                .NotEmpty().WithMessage("Por favor, preencha o Nome.")
                .NotNull().WithMessage("Por favor, preencha o Nome.");
        }
    }
}
