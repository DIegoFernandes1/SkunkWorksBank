using SkunkWorksBank.Domain.Shared.Exceptions;

namespace SkunkWorksBank.Domain.Users.ValueObjects.Exceptions
{
    public class InvalidNameLenghtException(string message) : DomainException(message);
}
