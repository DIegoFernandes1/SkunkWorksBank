using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Domain.Shared.ValueObjects;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;

namespace SkunkWorksBank.Domain.Users.ValueObjects
{
    public sealed record Name : ValueObject
    {
        #region Constants
        public const int MinLenght = 5;
        public const int MaxLenght = 60;
        #endregion

        #region Properties
        public string Value { get; }

        #endregion

        #region Constructors
        private Name()
        {

        }
        private Name(string value)
        {
            Value = value;
        }
        #endregion

        #region Factories
        public static Result<Name> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Name>(new Error(HttpCode.UNPROCESSABLE_CONTENT_422, Message.NAME_EMPTY_OR_NULL));

            if (name.Length < MinLenght)
                return Result.Failure<Name>(new Error(HttpCode.UNPROCESSABLE_CONTENT_422, Message.NAME_MIN_LENGHT));

            if (name.Length > MaxLenght)
                return Result.Failure<Name>(new Error(HttpCode.UNPROCESSABLE_CONTENT_422, Message.NAME_MAX_LENGHT));

            return Result.Success(new Name(name));
        }
        #endregion

        #region Operators
        public static implicit operator string(Name name) => name.Value.ToString();
        #endregion

        #region Override
        public override string ToString() => Value;
        #endregion
    }
}
