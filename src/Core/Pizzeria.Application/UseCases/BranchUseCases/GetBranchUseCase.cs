using Pizzeria.Application.DTOs.Response.Branch;
using Pizzeria.Application.Ports.BranchUseCases;
using Pizzeria.Domain.Ports.Repositories;

namespace Pizzeria.Application.UseCases.BranchUseCases;

public class GetBranchUseCase(IBranchRepository repository) : IGetBranchUseCase
{
    public async Task<BranchResponse?> ExecuteAsync(Guid id)
    {
        var branch = await repository.GetByIdAsync(id);
        if (branch is null)
        {
            return null;
        }

        return new BranchResponse
        {
            Id = branch.Id,
            Name = branch.Name,
            Address = branch.Address,
            CountryCode = branch.Phone.CountryCode,
            NationalNumber = branch.Phone.NationalNumber,
            Extension = branch.Phone.Extension,
            PhoneType = branch.Phone.PhoneType,
            IsOpen = branch.IsOpen,
            Schedules = branch.Schedules
        };
    }
}
