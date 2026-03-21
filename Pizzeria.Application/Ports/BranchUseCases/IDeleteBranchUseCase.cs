using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Ports.BranchUseCases;

public interface IDeleteBranchUseCase
{
    public Task<TypedResult<Branch>> ExecuteAsync(Guid id);
}
