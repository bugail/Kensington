using System;
using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Results;
using Kensington.Services.Requests;

namespace Kensington.Services.Interfaces;

/// <summary>
/// The user service interface.
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Get a user record
    /// </summary>
    /// <param name="id">The Id</param>
    /// <param name="token">A <see cref="CancellationToken"/></param>
    /// <returns>A <see cref="UserResult"/>.</returns>
    Task<UserResult> GetAsync(Guid id, CancellationToken token = default);

    Task<UserResult> PostAsync(UserRequest request, CancellationToken token = default);
}