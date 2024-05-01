// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzRequestValidatorTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using FluentValidation.TestHelper;
using Kensington.Api.QueryRequests;
using Kensington.Api.Validators;
using NUnit.Framework;

namespace Kensington.Api.IntegrationTests.Validators
{
    public class FizzBuzzQueryRequestValidatorTests
    {
        private FizzBuzzQueryRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new FizzBuzzQueryRequestValidator();
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("12x")]
        public void Validate_InvalidStart_HasErrors(string value)
        {
            // Arrange
            var model = new FizzBuzzQueryRequest { Start = value, End = string.Empty };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(person => person.Start);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("12x")]
        [TestCase("0")]
        public void Validate_InvalidEnd_HasErrors(string value)
        {
            // Arrange
            var model = new FizzBuzzQueryRequest { Start = string.Empty, End = value };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(person => person.End);
        }
    }
}