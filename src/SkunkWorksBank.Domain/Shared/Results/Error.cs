using SkunkWorksBank.Domain.Shared.Common;

namespace SkunkWorksBank.Domain.Shared.Results
{
    public record Error(int Code, string Message)
    {
        public static Error None = new(0, string.Empty);
        public static Error NullValue = new(HttpCode.BAD_REQUEST_400, "Um valor nulo foi fornecido.");
    }
}
