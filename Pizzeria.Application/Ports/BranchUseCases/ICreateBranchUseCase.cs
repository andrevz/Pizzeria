using Pizzeria.Application.DTOs.Request.Branch;
using Pizzeria.Application.DTOs.Response.Branch;
using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Ports.BranchUseCases;

public interface ICreateBranchUseCase
{
    Task<TypedResult<BranchResponse>> ExecuteAsync(CreateBranchRequest request);
}
