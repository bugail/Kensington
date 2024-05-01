using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kensington.DataAccess.Core;

public interface IDbContext<TEntity, TId>
    where TEntity : PrimaryKeyEntity<TId>
{
    ChangeTracker ChangeTracker { get; }
    DbSet<TEntity> GetAggregateRoot<T>()
        where T : TEntity;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}