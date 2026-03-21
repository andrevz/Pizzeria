namespace Pizzeria.Application.Results;

public abstract record BaseResult(bool IsSuccess, string? ErrorMessage);
