using SkunkWorksBank.Domain.Shared.Exceptions;

namespace SkunkWorksBank.Domain.Users.ValueObjects.Exceptions
{
    public sealed class InvalidCpfLenghtException(string message) : DomainException(message);
}
