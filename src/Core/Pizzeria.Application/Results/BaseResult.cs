namespace Pizzeria.Application.Results;

public abstract record class BaseResult
{
    public bool IsSuccess { get; init; }
    public string? ErrorMessage { get; init; }

    protected BaseResult(bool isSuccess, string? errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}
