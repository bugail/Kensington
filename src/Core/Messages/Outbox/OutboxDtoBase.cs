// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="OutboxDtoBase.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Text.Json;

namespace Kensington.Core.Messages.Outbox
{
    /// <summary>
    /// The base outbox message DTO.
    /// </summary>
    /// <typeparam name="T">The type of message to send.</typeparam>
    public class OutboxDtoBase<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string Type { get; protected internal set; }

        /// <summary>
        /// Gets the payload. This will be a JSON serialised string.
        /// </summary>
        public string Payload => JsonSerializer.Serialize(this.Object);

        /// <summary>
        /// Gets or sets the current object.
        /// </summary>
        public T Object { get; protected internal set; }
    }
}