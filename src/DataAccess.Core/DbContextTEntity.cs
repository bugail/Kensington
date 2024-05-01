using Microsoft.EntityFrameworkCore;

namespace Kensington.DataAccess.Core;

/// <inheritdoc/>
public abstract class DbContext<TEntity, TKey> : Microsoft.EntityFrameworkCore.DbContext,
    IDbContext<TEntity, TKey>
    where TEntity : PrimaryKeyEntity<TKey>
{
    protected DbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<TEntity> AggregateRoot { get; set; }

    /// <inheritdoc/>
    public DbSet<TEntity> GetAggregateRoot<T>()
        where T : TEntity
    {
        return AggregateRoot;
    }
}