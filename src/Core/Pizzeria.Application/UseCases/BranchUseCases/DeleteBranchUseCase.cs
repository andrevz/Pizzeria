using Pizzeria.Application.Ports.BranchUseCases;
using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;
using Pizzeria.Domain.Ports.Repositories;
using Pizzeria.Domain.Ports.Services;

namespace Pizzeria.Application.UseCases.BranchUseCases;

public class DeleteBranchUseCase(IBranchRepository repository, IUnitOfWork unitOfWork) : IDeleteBranchUseCase
{
    public async Task<TypedResult<Branch>> ExecuteAsync(Guid id)
    {
        var branch = await repository.GetByIdAsync(id);
        if (branch is null)
        {
            return TypedResult<Branch>.Failure("Branch not found");
        }

        branch.DeleteBranch();
        await unitOfWork.SaveChangesAsync();

        return TypedResult<Branch>.Success(branch);
    }
}
