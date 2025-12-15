using SkunkWorksBank.Domain.Shared.Exceptions;

namespace SkunkWorksBank.Domain.Users.ValueObjects.Exceptions
{
    public class InvalidNameExpection(string message) : DomainException(message);
}
