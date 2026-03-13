namespace Pizzeria.Application.Results;

public sealed record class TypedResult<T> : BaseResult
{
    public T? Value { get; init; }

    private TypedResult(bool isSuccess, string? errorMessage, T? value)
        : base(isSuccess, errorMessage)
    {
        Value = value;
    }

    public static TypedResult<T> Success(T value) => new(true, null, value);
    public static TypedResult<T> Failure(string errorMessage) => new(false, errorMessage, default);
}
