using System;

namespace Kensington.DataAccess.Core;

/// <inheritdoc/>
public abstract class BaseEntity<TId> :
    PrimaryKeyEntity<TId>,
    IAuditable,
    ISoftDelete
{
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsArchived { get; set; } = false;
}