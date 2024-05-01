// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="OutboxMessengerRepository.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Messages.Outbox;
using Kensington.DataAccess.Entities;
using Kensington.DataAccess.Interfaces;

namespace Kensington.DataAccess.Repositories;

/// <summary>
/// The outbox messenger class.
/// </summary>
public class OutboxMessengerRepository : IOutboxMessengerRepository
{
    private readonly KensingtonDbContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="OutboxMessengerRepository"/> class.
    /// </summary>
    /// <param name="context">The DB context.</param>
    public OutboxMessengerRepository(KensingtonDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="IOutboxMessengerRepository" />
    public async Task SendMessageAsync<T>(OutboxDtoBase<T> message, CancellationToken token = default)
        where T : class, new()
    {
        var entity = OutboxMessage.CreateOutboxMessage(message.Type, message.Payload, DateTime.UtcNow);
        await context.AddAsync(entity, token);
    }
}