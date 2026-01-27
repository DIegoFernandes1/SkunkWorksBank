using SkunkWorksBank.Domain.Shared.Exceptions;

namespace SkunkWorksBank.Domain.UserContext.ValueObjects.Exceptions
{
    public class InvalidUnknownContactTypeException(string message) : DomainException(message);
}
