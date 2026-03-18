using Pizzeria.Application.DTOs.Response.Branch;

namespace Pizzeria.Application.Ports.BranchUseCases;

public interface IGetBranchUseCase
{
    Task<BranchResponse?> ExecuteAsync(Guid id);
}
