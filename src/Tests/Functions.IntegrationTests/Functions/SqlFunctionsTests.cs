using System;
using FluentAssertions;
using Kensington.Functions.Functions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace Kensington.Functions.IntegrationTests.Functions;

public class SqlFunctionsTests
{
    private ILogger<SqlFunctions> logger;
    private SqlFunctions target;

    [SetUp]
    public void Setup()
    {
        logger = Substitute.For<ILogger<SqlFunctions>>();
        target = new SqlFunctions(logger);
    }

    [Test]
    public void Run_NullMessages_Doesnt_Throw_ReferenceException()
    {
        // Act
        var act = () => this.target.RunSqlTrigger(null);

        // Assert
        act
            .Should()
            .NotThrow<NullReferenceException>();
    }

    [Test]
    public void Run_NullMessages_Throws_ArgumentException()
    {
        // Act
        var act = () => this.target.RunSqlTrigger(null);

        // Assert
        act
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*Parameter 'messages'*");
    }
}