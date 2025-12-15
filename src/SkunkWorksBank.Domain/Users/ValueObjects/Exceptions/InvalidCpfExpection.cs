using SkunkWorksBank.Domain.Shared.Exceptions;

namespace SkunkWorksBank.Domain.Users.ValueObjects.Exceptions
{
    public sealed class InvalidCpfExpection(string message) : DomainException(message);
}
