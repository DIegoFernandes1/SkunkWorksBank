using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Domain.Shared.ValueObjects;
using SkunkWorksBank.Domain.UserContext.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace SkunkWorksBank.Domain.UserContext.ValueObjects
{
    public sealed record ContactValue : ValueObject
    {
        #region Constants
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
        private static readonly Regex PhoneRegex = new(@"^(\(?[1-9]{2}\)?)\s?(9?[0-9]{4}-?[0-9]{4})$", RegexOptions.Compiled);
        #endregion

        #region Properties
        public string Value { get; }

        #endregion

        #region Constructors
        private ContactValue() { }

        private ContactValue(string value)
        {
            Value = value;
        }
        #endregion

        #region Factory
        public static Result<ContactValue> Create(string value)
        {
            if (string.IsNullOrEmpty(value)
                || string.IsNullOrWhiteSpace(value))
                return Result.Failure<ContactValue>(new Error("422", "Campo não pode ser vazio."));

            if (EmailRegex.IsMatch(value)
                || PhoneRegex.IsMatch(value))
                return Result.Success(new ContactValue(value));

            return Result.Failure<ContactValue>(new Error("422", "É necessário informar um contato válido."));
        }
        #endregion

        #region Operator
        public static implicit operator string(ContactValue ContactValue) => ContactValue.Value.ToString();
        #endregion

        #region Overrides
        public override string ToString() => Value;
        #endregion
    }
}
