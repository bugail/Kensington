// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IOutboxMessengerService.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Messages.Outbox;

namespace Kensington.Services.Interfaces;

/// <summary>
/// The outbox messenger service interface.
/// </summary>
public interface IOutboxMessengerService
{
    /// <summary>
    /// Sends a message to the outbox.
    /// </summary>
    /// <typeparam name="T">The message type to send.</typeparam>
    /// <param name="message">The message.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    Task SendMessageAsync<T>(OutboxDtoBase<T> message, CancellationToken token = default)
        where T : class, new();
}