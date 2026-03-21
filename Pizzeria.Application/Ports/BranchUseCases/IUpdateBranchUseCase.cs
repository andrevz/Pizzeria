using Pizzeria.Application.DTOs.Request.Branch;
using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Ports.BranchUseCases;

public interface IUpdateBranchUseCase
{
    Task<TypedResult<Branch>> ExecuteAsync(Guid branchId, UpdateBranchRequest request);
}
