using Pizzeria.Application.DTOs.Request;
using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Ports.BranchUseCases;

public interface ICreateBranchUseCase
{
    Task<TypedResult<Branch>> ExecuteAsync(CreateBranchRequest request);
}
