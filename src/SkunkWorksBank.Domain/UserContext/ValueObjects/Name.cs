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
                return Result.Failure<Name>(new Error("422", "Nome não pode ser vazio."));

            if (name.Length < MinLenght)
                return Result.Failure<Name>(new Error("422", $"Nome deve ter no minimo {MinLenght} caracteres."));

            if (name.Length > MaxLenght)
                return Result.Failure<Name>(new Error("422", $"Nome deve ter no máximo {MaxLenght} caracteres."));

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
