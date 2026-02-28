using System.Diagnostics.CodeAnalysis;

namespace SkunkWorksBank.Domain.Shared.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        protected Result(bool isSuccess, Error error)
        {
            switch (isSuccess)
            {
                case true when error != Error.None:
                case false when error == Error.NullValue:
                    throw new InvalidOperationException();

                default:
                    IsSuccess = isSuccess;
                    Error = error;
                    break;
            }
        }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T>(T value) => new(value, true, Error.None);

        public static Result<T> Failure<T>(Error error) => new(default, false, error);

        public static Result<T> Create<T>(T? value)
            => value is not null ? Success(value) : Failure<T>(Error.NullValue);

        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.IsFailure)
                    return Failure(result.Error);
            }

            return Success();
        }
    }

    public class Result<T> : Result
    {
        private readonly T? _value;

        protected internal Result(T? value, bool isSuccess, Error error) : base(isSuccess, error)
            => _value = value;

        [NotNull]
        public T Value => _value ?? throw new InvalidOperationException("Erro: Retorno não tem um valor válido.");

        public static implicit operator Result<T>(T? value) => Create<T>(value);

        public Result<TOut> Map<TOut>(Func<T, TOut> mapper)
        {
            if (IsFailure)
                return Failure<TOut>(Error);

            return Success(mapper(Value));
        }

        public Result<T> Tap(Action<T> action)
        {
            if (IsSuccess)
                action(Value);

            return this;
        }

        public async Task<Result<T>> TapAsync(Func<T, Task> action)
        {
            if (IsFailure)
                return this;

            await action(Value);
            return this;
        }
    }

    public static class ResultExtensions
    {
        public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, Func<T, Task> action)
        {
            var result = await resultTask;

            if (result.IsFailure)
                return result;

            await action(result.Value);
            return result;
        }
    }
}
