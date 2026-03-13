using Pizzeria.Application.Ports.BranchUseCases;

namespace Pizzeria.Application.Contracts.UseCases;

public record class BranchUseCases(ICreateBranchUseCase Create);
