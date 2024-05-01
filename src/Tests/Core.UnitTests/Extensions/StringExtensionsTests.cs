// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensionsTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using FluentAssertions;
using Kensington.Core.Extensions;

namespace Kensington.Core.UnitTests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("bob", false)]
        [TestCase("12x", false)]
        [TestCase("1337", true)]
        [TestCase("01", true)]
        public void IsNumeric_ValidString_ReturnsCorrectResult(string value, bool expectedResult)
        {
            // Act
            var result = value.IsNumeric();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}