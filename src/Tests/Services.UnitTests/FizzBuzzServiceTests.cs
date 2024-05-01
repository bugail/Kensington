// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzServiceTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kensington.Services.Interfaces;
using Kensington.Services.Requests;
using Kensington.Services.Strategies.Fizzbuzz;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Kensington.Services.UnitTests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private List<IFizzBuzzStrategy> stategies;
        private FizzBuzzService target;
        private ILogger<FizzBuzzService> logger;

        [SetUp]
        public void Setup()
        {
            this.logger = Substitute.For<ILogger<FizzBuzzService>>();
            this.stategies = new List<IFizzBuzzStrategy>
            {
                new FizzStrategy(),
                new BuzzStrategy()
            };

            this.target = new FizzBuzzService(this.stategies, this.logger);
        }

        [Test]
        public void GetFizzBuzzList_ValidCollection_ReturnsValidResults()
        {
            // Arrange
            var list = Enumerable.Range(1, 100).ToList();

            // Act
            var results = this.target.GetFizzBuzzResults(list);

            // Assert
            results.ToList().Count.Should().Be(100);
        }

        [Test]
        public void GetFizzBuzzList_NullCollection_ThrowsException()
        {
            // Arrange
            List<int> collection = null;

            // Act
            Func<IEnumerable<string>> action = () => this.target.GetFizzBuzzResults(collection);

            // Assert
            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("*collection*");
        }

        [Test]
        public void GetFizzBuzzList_EmptyCollection_ThrowsException()
        {
            // Arrange
            List<int> collection = new List<int>();

            // Act
            Func<IEnumerable<string>> action = () => this.target.GetFizzBuzzResults(collection);

            // Assert
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("*collection*");
        }

        [Test]
        public void GetFizzBuzzList_NullRequest_ThrowsException()
        {
            // Arrange
            FizzBuzzRequest request = null;

            // Act
            Func<IEnumerable<string>> action = () => this.target.GetFizzBuzzResults(request);

            // Assert
            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("*request*");
        }
    }
}