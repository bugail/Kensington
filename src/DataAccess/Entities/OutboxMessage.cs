// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="OutboxMessage.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using Kensington.DataAccess.Core;

namespace Kensington.DataAccess.Entities
{
    /// <summary>
    /// The outbox messages entity.
    /// </summary>
    public class OutboxMessage : PrimaryKeyEntity<Guid>
    {
        /// <summary>
        /// Gets or sets the date the message was raised.
        /// </summary>
        public DateTime RaisedDate { get; set; }

        /// <summary>
        /// Gets or sets the processed date. This is the date the message was processed.
        /// </summary>
        public DateTime? ProcessedDate { get; set; }

        /// <summary>
        /// Gets or sets the type. This is the type of message being sent.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the payload. This will be a JSON serialised string.
        /// </summary>
        public string Data { get; set; }

        /// <summary>Create Outbox Message.</summary>
        /// <param name="type">The message type.</param>
        /// <param name="data">The json data string.</param>
        /// <param name="raisedDate">The date the message was raised.</param>
        /// <returns>A <see cref="OutboxMessage" /> populated and ready to send.</returns>
        public static OutboxMessage CreateOutboxMessage(string type, string data, DateTime raisedDate)
        {
            return new OutboxMessage
            {
                Type = type,
                Data = data,
                RaisedDate = raisedDate
            };
        }
    }
}