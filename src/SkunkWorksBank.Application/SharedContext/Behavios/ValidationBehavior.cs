using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using FluentValidation;
using MediatR;

namespace SkunkWorksBank.Application.SharedContext.Behavios
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse> 
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any() == false)
                return await next();

            var context = new ValidationContext<TRequest>(request);
            var validationErros = validators
                .Select(x => x.Validate(context))
                .Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors)
                .Select(x => new ValidationError(x.PropertyName, x.ErrorMessage))
                .ToList();

            if (validationErros.Any())
                throw new ValidationException(validationErros);

            return await next();
        }
    }

    public sealed record ValidationError(string propertyName, string ErrorMessage);

    public sealed class ValidationException : Exception
    {
        public IEnumerable<ValidationError> Errors { get; }
        public ValidationException(IEnumerable<ValidationError> errors)
            => Errors = errors;
    }
}
