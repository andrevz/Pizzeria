using Pizzeria.Application.DTOs.Request.Branch;
using Pizzeria.Application.Ports.BranchUseCases;
using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;
using Pizzeria.Domain.Ports.Repositories;
using Pizzeria.Domain.Ports.Services;

namespace Pizzeria.Application.UseCases.BranchUseCases;

public class UpdateBranchUseCase(IBranchRepository repository, IUnitOfWork unitOfWork) : IUpdateBranchUseCase
{
    public async Task<TypedResult<Branch>> ExecuteAsync(Guid branchId, UpdateBranchRequest request)
    {
        var branch = await repository.GetByIdAsync(branchId);
        if (branch is null)
        {
            return TypedResult<Branch>.Failure("Branch not found");
        }

        var phone = Domain.ValueObjects.PhoneNumber.Create(request.CountryCode, request.NationalNumber, request.Extension, request.PhoneType);
        
        branch.UpdateBranch(request.Name, request.Address, phone, request.IsOpen);
        
        repository.Update(branch);
        await unitOfWork.SaveChangesAsync();
        return TypedResult<Branch>.Success(branch);
    }
}
