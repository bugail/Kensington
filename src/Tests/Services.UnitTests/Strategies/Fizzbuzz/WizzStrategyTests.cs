// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WizzStrategyTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using FluentAssertions;
using Kensington.Core.Constants;
using Kensington.Services.Strategies.Fizzbuzz;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Kensington.Services.UnitTests.Strategies.Fizzbuzz
{
    [TestFixture]
    public class WizzStrategyTests
    {
        private ILogger<WizzStrategy> logger;
        private WizzStrategy target;

        [SetUp]
        public void Setup()
        {
            this.logger = Substitute.For<ILogger<WizzStrategy>>();
            this.target = new WizzStrategy();
        }

        [TestCase(1, "")]
        [TestCase(3, "")]
        [TestCase(5, "")]
        [TestCase(15, "")]
        [TestCase(27, "")]
        [TestCase(100, OutputConstants.WizzMessage)]
        [TestCase(101, "")]
        public void Execute_ValidValue_ReturnsCorrectResult(int value, string expectedResult)
        {
            // Arrange

            // Act
            var result = this.target.Execute(value);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}