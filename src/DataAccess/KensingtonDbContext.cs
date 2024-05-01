using System;
using System.Data;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Kensington.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Kensington.DataAccess;

/// <summary>
/// The application DB context.
/// </summary>
public class KensingtonDbContext : DbContext
{
    private IDbContextTransaction currentTransaction;

    /// <summary>
    /// Initializes a new instance of the <see cref="KensingtonDbContext"/> class.
    /// </summary>
    /// <param name="options">The DB options</param>>
    public KensingtonDbContext(
        DbContextOptions<KensingtonDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the context has a transaction.
    /// True if context has a transaction, False if it doesn't.
    /// </summary>
    public bool HasActiveTransaction => currentTransaction != null;

    /// <summary>
    /// Gets or sets the outbox message collection.
    /// </summary>
    public virtual DbSet<OutboxMessage> OutboxMessages { get; set; }

    /// <summary>
    /// Gets or setsthe users collection.
    /// </summary>
    public virtual DbSet<User> Users { get; set; }

    /// <summary>
    /// Starts a transaction.
    /// </summary>
    /// <returns>A <see cref="IDbContextTransaction"/>.</returns>
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (currentTransaction != null)
        {
            return null;
        }

        currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return currentTransaction;
    }

    /// <summary>
    /// Commits a transaction.
    /// </summary>
    /// <param name="transaction">The current transaction.</param>
    /// <exception cref="ArgumentNullException">Throws id transaction is null.</exception>
    /// <exception cref="InvalidOperationException">Throws is transaction is not the current one</exception>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        Guard.Against.Null(transaction, nameof(transaction));

        if (transaction != currentTransaction)
        {
            throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
        }

        try
        {
            await SaveChangesAsync();
            transaction.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (currentTransaction != null)
            {
                currentTransaction.Dispose();
                currentTransaction = null;
            }
        }
    }

    /// <summary>
    /// Handles rolling back a transaction
    /// </summary>
    public void RollbackTransaction()
    {
        try
        {
            currentTransaction?.Rollback();
        }
        finally
        {
            if (currentTransaction != null)
            {
                currentTransaction.Dispose();
                currentTransaction = null;
            }
        }
    }
}