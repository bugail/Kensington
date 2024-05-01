using System;
using FluentAssertions;
using Kensington.Core.Extensions;
using Kensington.Core.Queries.Users;

namespace Kensington.Core.UnitTests.Extensions;

public class TypeExtensionsTests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase(typeof(GetUserQuery), nameof(GetUserQuery))]
        public void GetGenericTypeName_ValidType_ReturnsCorrectResult(Type value, string expectedResult)
        {
            // Act
            var result = value.GetGenericTypeName();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}