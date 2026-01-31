using FluentValidation;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Contacts
{
    public class Validation : AbstractValidator<ContactCommand>
    {
        public Validation()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage($"O contato não pode ser vazio.");
        }
    }
}
