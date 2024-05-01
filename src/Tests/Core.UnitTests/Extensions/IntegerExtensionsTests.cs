// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IntegerExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Kensington.Core.Extensions;

namespace Kensington.Core.UnitTests.Extensions
{
    public class IntegerExtensionsTests
    {
        [TestCase(1, 1, true)]
        [TestCase(0, 1, true)]
        [TestCase(2, 3, false)]
        [TestCase(15, 3, true)]
        [TestCase(15, 5, true)]
        [TestCase(16, 3, false)]
        [TestCase(16, 5, false)]
        [TestCase(16, 5, false)]
        public void IsDivisableBy_ValidValues_ReturnsCorrectResult(int value, int divider, bool expectedResult)
        {
            // Arrange

            // Act
            var result = value.IsDivisableBy(divider);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        [TestCase(5, 120)]
        [TestCase(6, 720)]
        public void Factorial_PositiveValues_ReturnsValidResult(int value, int expectedResult)
        {
            // Act
            var result = value.Factorial();

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-3)]
        [TestCase(-4)]
        [TestCase(-5)]
        [TestCase(-6)]
        public void Factorial_NegativeValue_ThrowsException(int value)
        {
            // Act
            var result = () => value.Factorial();

            // Assert
            result.Should()
                .Throw<ArgumentException>()
                .WithMessage("*Factorial value must be positive*");
        }
    }
}