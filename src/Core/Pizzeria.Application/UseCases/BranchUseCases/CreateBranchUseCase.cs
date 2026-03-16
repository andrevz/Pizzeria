using Pizzeria.Application.DTOs.Request.Branch;
using Pizzeria.Application.Ports.BranchUseCases;
using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;
using Pizzeria.Domain.Ports.Repositories;
using Pizzeria.Domain.Ports.Services;
using Pizzeria.Domain.ValueObjects;

namespace Pizzeria.Application.UseCases.BranchUseCases;

public class CreateBranchUseCase : ICreateBranchUseCase
{
    private readonly IBranchRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBranchUseCase(IBranchRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TypedResult<Branch>> ExecuteAsync(CreateBranchRequest request)
    {
        var existingBranch = await _repository.FindAsync(b => b.Name == request.Name);
        if (existingBranch is not null)
        {
            return TypedResult<Branch>.Failure("A branch with the same name already exists.");
        }
        
        var branch = Branch.Create(name: request.Name,
                                   address: request.Address,
                                   phone: PhoneNumber.Create(request.CountryCode, request.NationalNumber, request.Extension, request.PhoneType),
                                   isOpen: request.IsOpen);

        await _repository.AddAsync(branch);
        await _unitOfWork.SaveChangesAsync();

        return TypedResult<Branch>.Success(branch);
    }
}
