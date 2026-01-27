using SkunkWorksBank.Domain.Shared.Exceptions;

namespace SkunkWorksBank.Domain.UserContext.ValueObjects.Exceptions
{
    public class InvalidContactValueException(string message) : DomainException(message);
}
