using SkunkWorksBank.Domain.Shared.Exceptions;

namespace SkunkWorksBank.Domain.Users.ValueObjects.Exceptions
{
    public class InvalidBirthDateException(string message) : DomainException(message);
}
