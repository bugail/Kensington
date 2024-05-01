// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="OutboxMessengerService.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Messages.Outbox;
using Kensington.DataAccess.Interfaces;

namespace Kensington.Services.Interfaces;

/// <inheritdoc cref="IOutboxMessengerService" />
public class OutboxMessengerService : IOutboxMessengerService
{
    private readonly IOutboxMessengerRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="OutboxMessengerService"/> class.
    /// </summary>
    /// <param name="repository">The repository</param>
    public OutboxMessengerService(IOutboxMessengerRepository repository)
    {
        this.repository = repository;
    }

    /// <inheritdoc cref="IOutboxMessengerService" />
    public Task SendMessageAsync<T>(OutboxDtoBase<T> message, CancellationToken token)
        where T : class, new()
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return this.repository.SendMessageAsync(message, token);
    }
}