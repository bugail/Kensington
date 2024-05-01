using System;
using System.Threading;
using System.Threading.Tasks;
using Kensington.DataAccess.Entities;
using Kensington.DataAccess.Queries;

namespace Kensington.DataAccess.Interfaces;

/// <summary>
/// The user repository.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Gets a user from the DB.
    /// </summary>
    /// <param name="id">The Id</param>
    /// <param name="token">A <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="User"/>.</returns>
    Task<User> GetAsync(Guid id, CancellationToken token = default);

    Task<User> PostAsync(UserQuery query, CancellationToken token);
}