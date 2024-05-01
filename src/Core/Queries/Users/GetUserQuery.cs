// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GetUserQuery.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using Kensington.Core.Results;
using MediatR;

namespace Kensington.Core.Queries.Users;

public class GetUserQuery : IRequest<UserResult>
{
    public GetUserQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}