using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using FluentAssertions;
using Kensington.Functions.Functions;
using Microsoft.Azure.Functions.Worker;
using NSubstitute;
using NUnit.Framework;

namespace Kensington.Functions.IntegrationTests.Functions;

public class ServiceBusFunctionTests
{
    private ServiceBusFunctions target;
    private ServiceBusMessageActions messageActions;

    [SetUp]
    public void Setup()
    {
        target = new ServiceBusFunctions();
        messageActions = Substitute.For<ServiceBusMessageActions>();
    }

    [Test]
    public async Task Run_ValidMessage_Doesnt_Throw_Exceptions()
    {
        // Arrange
        var receivedMessage = CreateMessage("Valid Content", "123");

        // Act
        var act = () => target.RunServiceBusTrigger(receivedMessage, messageActions);

        // Assert
        await act.Should().NotThrowAsync();
    }

    [Test]
    public async Task Run_InvalidMessage_Throw_Exceptions()
    {
        // Arrange
        var receivedMessage = CreateMessage("Invalid content", "123");

        // Act
        var act = () => target.RunServiceBusTrigger(receivedMessage, messageActions);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    private ServiceBusReceivedMessage CreateMessage(string message, string messageId)
    {
        return ServiceBusModelFactory.ServiceBusReceivedMessage(
            new BinaryData(message),
            messageId,
            null,
            null,
            null,
            null,
            TimeSpan.FromHours(1),
            null,
            null,
            null,
            "text/plain");
    }
}