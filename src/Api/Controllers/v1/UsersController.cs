// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UsersController.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kensington.Api.QueryRequests;
using Kensington.Api.Responses;
using Kensington.Core.Commands;
using Kensington.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kensington.Api.Controllers.v1;

/// <summary>
/// The users controller.
/// </summary>
[Route("api/v1/[controller]")]
public class UsersController : BaseController
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public UsersController(
        IMediator mediator,
        IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    /// <summary>
    /// Gets a user.
    /// </summary>
    /// <param name="id">The user id.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A<see cref="UserResponse"/>.</returns>
    [HttpGet(Name = nameof(GetAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<UserResponse> GetAsync([FromQuery] Guid id, CancellationToken token)
    {
        var query = new GetUserQuery(id);
        var result = await mediator.Send(query, token);

        return mapper.Map<UserResponse>(result);
    }

    [HttpPost(Name = nameof(PostAsync))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<UserResponse> PostAsync([FromBody] UserQueryRequest request, CancellationToken token)
    {
        var command = new CreateUserCommand(request.Firstname, request.Surname, request.Displayname);
        var result = await mediator.Send(command, token);

        return mapper.Map<UserResponse>(result);
    }
}