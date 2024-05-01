// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ServiceBusFunctions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Azure.Messaging.ServiceBus;
using Kensington.Functions.Constants;
using Microsoft.Azure.Functions.Worker;

namespace Kensington.Functions.Functions;

public class ServiceBusFunctions
{
    [Function(nameof(RunServiceBusTrigger))]
    public async Task RunServiceBusTrigger(
        [ServiceBusTrigger("queue", Connection = "ServiceBusConnection", AutoCompleteMessages = false)]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        if (message.Body.ToString() == "Invalid content")
        {
            throw new InvalidOperationException("Invalid Content");
        }

        await messageActions.CompleteMessageAsync(message);
    }

    // [Function(nameof(RunSendGrid))]
    // [SendGridOutput(ApiKey = "SendGrid:Key", To = "{EmailTo}", From = "{EmailFrom}")]
    // public async Task RunSendGrid(
    //     [ServiceBusTrigger(
    //         ServiceBusConstants.QueueName,
    //         Connection = ServiceBusConstants.ConnectionStringSetting,
    //         AutoCompleteMessages = false)]
    //     ServiceBusReceivedMessage message,
    //     ServiceBusMessageActions messageActions)
    // {
    //     if (message.Body.ToString() == "Invalid content")
    //     {
    //         throw new InvalidOperationException("Invalid Content");
    //     }
    //
    //     var email = new SendGridMessage();
    //     email.SetFrom(new EmailAddress("foo@foo.com", "Sender"));
    //     email.SetGlobalSubject("Check SendGrid output");
    //     email.AddTo(new EmailAddress("foo@foo.com", "To Address"));
    //     email.AddContent(MimeType.Text, "Mail to check SendGrid output from Azure Function");
    //
    //     await messageActions.CompleteMessageAsync(message);
    // }
}