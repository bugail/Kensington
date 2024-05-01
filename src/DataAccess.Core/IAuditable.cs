using System;

namespace Kensington.DataAccess.Core
{
    /// <summary>
    /// Interface for audit
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Gets or sets when the entity was created in the micro-service store.
        /// Not to be confused with CreatedOn that may come from customer data
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets when the entity was last updated in the micro-service store.
        /// Not to be confused with Timestamps that may come from customer data
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the UserId that executed action that motivated Entity being modified
        /// </summary>
        public Guid? LastModifiedBy { get; set; }
    }
}