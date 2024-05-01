using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kensington.Core.Results;
using Kensington.DataAccess.Interfaces;
using Kensington.DataAccess.Queries;
using Kensington.Services.Interfaces;
using Kensington.Services.Requests;
using Microsoft.Extensions.Logging;

namespace Kensington.Services;

/// <summary>
/// The user service.
/// </summary>
public class UsersService : IUsersService
{
    private readonly IUsersRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<UsersService> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersService"/> class.
    /// </summary>
    /// <param name="repository">The data repository.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="logger">The logger.</param>
    public UsersService(
        IUsersRepository repository,
        IMapper mapper,
        ILogger<UsersService> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task<UserResult> GetAsync(Guid id, CancellationToken token = default)
    {
        var result = await repository.GetAsync(id, token);
        return mapper.Map<UserResult>(result);
    }

    public async Task<UserResult> PostAsync(UserRequest request, CancellationToken token = default)
    {
        var query = mapper.Map<UserQuery>(request);
        var result = await repository.PostAsync(query, token);
        return mapper.Map<UserResult>(result);
    }
}