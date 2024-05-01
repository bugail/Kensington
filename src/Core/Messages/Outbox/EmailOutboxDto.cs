// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EmailOutboxDto.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Kensington.Core.Constants;
using Kensington.Core.Requests;

namespace Kensington.Core.Messages.Outbox
{
    /// <summary>
    /// The email transaction outbox message dto.
    /// </summary>
    public class EmailOutboxDto : OutboxDtoBase<EmailRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailOutboxDto"/> class.
        /// </summary>
        /// <param name="recipient">The recipient email address.</param>
        /// <param name="subject">The email subject</param>
        /// <param name="body">The email body. Will usually be as html.</param>
        public EmailOutboxDto(string recipient, string subject, string body)
        {
            this.Type = OutboxConstants.EmailMessageType;
            this.Object = new EmailRequest(recipient, subject, body);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailOutboxDto"/> class.
        /// </summary>
        /// <param name="recipients">The recipient email addresses.</param>
        /// <param name="subject">The email subject</param>
        /// <param name="body">The email body. Will usually be as html.</param>
        public EmailOutboxDto(IEnumerable<string> recipients, string subject, string body)
        {
            this.Type = OutboxConstants.EmailMessageType;
            this.Object = new EmailRequest(recipients, subject, body);
        }
    }
}