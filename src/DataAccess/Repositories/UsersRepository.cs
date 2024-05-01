using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kensington.DataAccess.Entities;
using Kensington.DataAccess.Interfaces;
using Kensington.DataAccess.Queries;
using Microsoft.EntityFrameworkCore;

namespace Kensington.DataAccess.Repositories;

/// <inheritdoc />
public class UsersRepository : IUsersRepository
{
    private readonly KensingtonDbContext context;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersRepository"/> class.
    /// </summary>
    /// <param name="context">The DB context.</param>
    /// <param name="mapper">The mapper.</param>
    public UsersRepository(KensingtonDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public Task<User> GetAsync(Guid id, CancellationToken token)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
    }

    public async Task<User> PostAsync(UserQuery query, CancellationToken token)
    {
        var user = mapper.Map<User>(query);
        var result = context.Users.Add(user);
        await context.SaveChangesAsync(token);

        return user;
    }
}