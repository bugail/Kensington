// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IOutboxMessengerRepository.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Messages.Outbox;

namespace Kensington.DataAccess.Interfaces;

/// <summary>
/// The outbox messaging repository.
/// </summary>
public interface IOutboxMessengerRepository
{
    /// <summary>
    /// Sends a message to the outbox queue.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="message">The message to send.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    Task SendMessageAsync<T>(OutboxDtoBase<T> message, CancellationToken token = default)
        where T : class, new();
}