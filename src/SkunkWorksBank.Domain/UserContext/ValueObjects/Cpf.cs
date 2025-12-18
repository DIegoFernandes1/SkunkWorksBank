using SkunkWorksBank.Domain.Shared.ValueObjects;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace SkunkWorksBank.Domain.Users.ValueObjects
{
    public sealed record Cpf : ValueObject
    {
        #region Constants
        private const int MaxLenght = 11;
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
        public static Cpf Create(string cpf)
        {

            if (string.IsNullOrEmpty(cpf)
                || string.IsNullOrWhiteSpace(cpf))
                throw new InvalidCpfException("CPF não pode ser vazio.");

            cpf = Regex.Replace(cpf.Trim(), @"\D", "");

            if (cpf.Length != MaxLenght)
                throw new InvalidCpfLenghtException($"CPF não tem {MaxLenght} números.");

            return new Cpf(cpf);
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
