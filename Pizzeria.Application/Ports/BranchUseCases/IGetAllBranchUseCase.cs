using Pizzeria.Application.DTOs.Response.Branch;

namespace Pizzeria.Application.Ports.BranchUseCases;

public interface IGetAllBranchUseCase
{
    Task<IEnumerable<BranchResponse>> ExecuteAsync();
}
