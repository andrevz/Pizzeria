using Microsoft.EntityFrameworkCore.Storage;
using Pizzeria.Domain.Ports.Services;
using Pizzeria.Infrastructure.Configuration.Context;

namespace Pizzeria.Infrastructure.Services;

public class UnitOfWork(PizzeriaDbContext context) : IUnitOfWork
{
    private IDbContextTransaction? _currentTransaction;

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            throw new InvalidOperationException("A transaction is already in progress");
        }

        _currentTransaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await SaveChangesAsync();

            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("No transaction in progress to commit");
            }

            await _currentTransaction.CommitAsync();
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            await DisposeAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }

        await context.DisposeAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        try
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("No transaction in progress to rollback");
            }

            await _currentTransaction.RollbackAsync();
        }
        finally
        {
            await DisposeAsync();
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
