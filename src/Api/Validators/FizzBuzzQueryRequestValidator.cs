// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzRequestValidator.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using FluentValidation;
using Kensington.Api.QueryRequests;
using Kensington.Core.Extensions;

namespace Kensington.Api.Validators
{
    /// <summary>
    /// The fizz buzz validator.
    /// </summary>
    public class FizzBuzzQueryRequestValidator : AbstractValidator<FizzBuzzQueryRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzQueryRequestValidator"/> class.
        /// </summary>
        public FizzBuzzQueryRequestValidator()
        {
            this.RuleFor(x => x.Start)
                .NotEmpty()
                .NotNull()
                .Must(x => x.IsNumeric()).WithMessage("Start must be a valid number");

            this.RuleFor(x => x.End)
                .NotEmpty()
                .NotNull()
                .Must(x => x.IsNumeric()).WithMessage("End must be a valid number")
                .Custom((x, context) =>
                {
                    if (!int.TryParse(x, out int value) || value <= 0)
                    {
                        context.AddFailure($"End must be greater than 0.");
                    }
                });
        }
    }
}