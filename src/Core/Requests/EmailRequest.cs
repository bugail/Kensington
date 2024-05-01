// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EmailRequest.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Kensington.Core.Requests;

/// <summary>The email request payload for the message queue.</summary>
public class EmailRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmailRequest" /> class.
    /// </summary>
    /// <param name="recipients">The recipient email addresses.</param>
    /// <param name="subject">The email subject</param>
    /// <param name="body">The email body. Will usually be as html.</param>
    public EmailRequest(IEnumerable<string> recipients, string subject, string body)
    {
        this.Recipients = recipients;
        this.Subject = subject;
        this.Body = body;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailRequest" /> class.
    /// </summary>
    /// <param name="recipient">The recipient email address.</param>
    /// <param name="subject">The email subject</param>
    /// <param name="body">The email body. Will usually be as html.</param>
    public EmailRequest(string recipient, string subject, string body)
    {
        this.Recipients = new List<string>
        {
            recipient
        };
        this.Subject = subject;
        this.Body = body;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailRequest" /> class.
    /// </summary>
    public EmailRequest()
    {
    }

    /// <summary>Gets or sets the email recipients.</summary>
    public IEnumerable<string> Recipients { get; set; }

    /// <summary>Gets or sets the email subject.</summary>
    public string Subject { get; set; }

    /// <summary>Gets or sets the email body. Will usually be as html.</summary>
    public string Body { get; set; }
}