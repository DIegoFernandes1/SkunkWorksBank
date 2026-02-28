using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Domain.Shared.ValueObjects;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace SkunkWorksBank.Domain.Users.ValueObjects
{
    public sealed record Cpf : ValueObject
    {
        #region Constants
        public const int MaxLenght = 11;
        #endregion

        #region Constructor
        private Cpf()
        {

        }
        private Cpf(string cpf)
        {
            Value = cpf;
        }
        #endregion

        #region Properties
        public string Value { get; }

        #endregion

        #region Factories
        public static Result<Cpf> Create(string cpf)
        {

            if (string.IsNullOrWhiteSpace(cpf))
                return Result.Failure<Cpf>(new Error("422", "CPF não pode ser vazio."));

            cpf = Regex.Replace(cpf.Trim(), @"\D", "");

            if (cpf.Length != MaxLenght)
                return Result.Failure<Cpf>(new Error("422", $"CPF não tem {MaxLenght} números."));

            return Result.Success(new Cpf(cpf));
        }
        #endregion

        #region Operatos
        public static implicit operator string(Cpf cpf) => cpf.ToString();

        #endregion

        #region Overrides
        public override string ToString() => Value;

        #endregion

    }
}
