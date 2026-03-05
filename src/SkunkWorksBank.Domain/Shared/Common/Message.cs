using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.Domain.Shared.Common
{
    public static class Message
    {
        //GENERAL
        public static string FIELD_EMPTY_OR_NULL { get; } = "Campo não pode ser vazio.";

        //VALUES OBJECTS
        public static string FUTURE_DATE { get; } = "Idade não pode ser futura.";
        public static string MAX_DATE { get; } = $"Idade máxima é de {BirthDate.MaxAge} anos.";
        public static string MIN_DATE { get; } = $"Idade minima é de {BirthDate.MinAge} anos.";
        public static string INVALID_CONTACT { get; } = "É necessário informar um contato válido.";
        public static string CPF_EMPTY_OR_NULL { get; } = "CPF não pode ser vazio.";
        public static string CPF_MAX_LENGHT { get; } = $"CPF não tem {Cpf.MaxLenght} números.";
        public static string NAME_EMPTY_OR_NULL { get; } = "Nome não pode ser vazio.";
        public static string NAME_MIN_LENGHT { get; } = $"Nome deve ter no minimo {Name.MinLenght} caracteres.";
        public static string NAME_MAX_LENGHT { get; } = $"Nome deve ter no máximo {Name.MaxLenght} caracteres.";
        
    }
}
