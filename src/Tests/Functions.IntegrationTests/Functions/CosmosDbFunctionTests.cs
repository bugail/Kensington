using System.Collections.Generic;
using FluentAssertions;
using Kensington.DataAccess.Entities;
using Kensington.Functions.Functions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace Kensington.Functions.IntegrationTests.Functions;

public class CosmosDbFunctionTests
{
    private CosmosDbFunction target;
    private ILogger<CosmosDbFunction> logger;

    [SetUp]
    public void Setup()
    {
        logger = Substitute.For<ILogger<CosmosDbFunction>>();
        target = new CosmosDbFunction(logger);
    }

    [Test]
    public void Run()
    {
        // Arrange
        var documents = new List<OutboxMessage>();

        // Act
        var act = () => target.RunCosmos(documents);

        // Assert
        act.Should().NotThrow();
    }
}