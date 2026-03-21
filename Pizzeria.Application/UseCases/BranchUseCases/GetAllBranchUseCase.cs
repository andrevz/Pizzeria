using Pizzeria.Application.DTOs.Response.Branch;
using Pizzeria.Application.Ports.BranchUseCases;
using Pizzeria.Domain.Ports.Repositories;

namespace Pizzeria.Application.UseCases.BranchUseCases;

public class GetAllBranchUseCase(IBranchRepository repository) : IGetAllBranchUseCase
{
    public async Task<IEnumerable<BranchResponse>> ExecuteAsync()
    {
        var branches = await repository.ListAsync();

        return branches.Select(b => new BranchResponse
        {
            Id = b.Id,
            Name = b.Name,
            Address = b.Address,
            CountryCode = b.Phone.CountryCode,
            NationalNumber = b.Phone.NationalNumber,
            Extension = b.Phone.Extension,
            PhoneType = b.Phone.PhoneType,
            IsOpen = b.IsOpen
        });
    }
}
