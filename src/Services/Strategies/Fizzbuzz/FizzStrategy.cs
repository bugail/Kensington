// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Kensington.Core.Constants;
using Kensington.Core.Extensions;

namespace Kensington.Services.Strategies.Fizzbuzz
{
    /// <summary>
    /// The fizz strategy.
    /// </summary>
    public class FizzStrategy : BaseStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FizzStrategy"/> class.
        /// </summary>
        public FizzStrategy()
            : base(
                i => i.IsDivisableBy(3),
                OutputConstants.FizzMessage)
        {
        }
    }
}