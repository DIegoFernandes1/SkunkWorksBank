using FluentValidation;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create
{
    public class Validation : AbstractValidator<Command>
    {
        public Validation()
        {
            RuleFor(x => x.Cpf)
                .Length(Cpf.MaxLenght)
                .WithMessage($"CPF deve conter {Cpf.MaxLenght} caracteres.");

            RuleFor(x => x.FullName)
                .MinimumLength(Name.MinLenght)
                .WithMessage($"Nome completo deve conter pelo menos {Name.MinLenght} caracteres.");

            RuleFor(x => x.FullName)
                .MaximumLength(Name.MaxLenght)
                .WithMessage($"Nome completo deve conter no máximo {Name.MaxLenght} caracteres.");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Nome completo não pode ser vazio.");

            RuleFor(x => x.BirthDate)
                .Must(date => date != default)
                .WithMessage("Data de nascimento deve ser informada.");

        }
    }
}
