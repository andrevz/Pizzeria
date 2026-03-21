using Pizzeria.Application.DTOs.Request.Branch;
using Pizzeria.Application.DTOs.Response.Branch;
using Pizzeria.Application.Ports.BranchUseCases;
using Pizzeria.Application.Results;
using Pizzeria.Domain.Entities;
using Pizzeria.Domain.Ports.Repositories;
using Pizzeria.Domain.Ports.Services;
using Pizzeria.Domain.ValueObjects;

namespace Pizzeria.Application.UseCases.BranchUseCases;

public class CreateBranchUseCase(IBranchRepository repository, IUnitOfWork unitOfWork) : ICreateBranchUseCase
{
    public async Task<TypedResult<BranchResponse>> ExecuteAsync(CreateBranchRequest request)
    {
        var existingBranch = await repository.FindAsync(b => b.Name == request.Name);
        if (existingBranch is not null)
        {
            return TypedResult<BranchResponse>.Failure("A branch with the same name already exists.");
        }
        
        var branch = Branch.Create(name: request.Name,
                                   address: request.Address,
                                   phone: PhoneNumber.Create(request.CountryCode, request.NationalNumber, request.Extension, request.PhoneType),
                                   isOpen: request.IsOpen);

        foreach (var day in Enum.GetValues<DayOfWeek>())
        {
            var isWeekend = day is DayOfWeek.Friday or DayOfWeek.Saturday;
            var closesAt = isWeekend ? new TimeOnly(23, 0) : new TimeOnly(22, 0);
            var opensAt = new TimeOnly(17, 00);

            var branchSchedule = BranchSchedule.Create(branch.Id, day, opensAt, closesAt);
            branch.AddBranchSchedule(branchSchedule);
        }

        await repository.AddAsync(branch);
        await unitOfWork.SaveChangesAsync();
        
        var response = new BranchResponse
        {
            Id = branch.Id,
            Name = branch.Name,
            Address = branch.Address,
            CountryCode = branch.Phone.CountryCode,
            NationalNumber = branch.Phone.NationalNumber,
            Extension = branch.Phone.Extension,
            PhoneType = branch.Phone.PhoneType,
            IsOpen = branch.IsOpen,
            Schedules = branch.Schedules.Select( bs => new BranchScheduleResponse
            {
                Id = bs.Id,
                Day = bs.Day,
                OpensAt = bs.OpensAt,
                ClosesAt = bs.ClosedAt
            })
        };

        return TypedResult<BranchResponse>.Success(response);
    }
}
