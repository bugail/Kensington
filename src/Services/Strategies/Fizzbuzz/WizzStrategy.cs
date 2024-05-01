// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WizzStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Kensington.Core.Constants;

namespace Kensington.Services.Strategies.Fizzbuzz
{
    /// <summary>
    /// The wizz strategy. Used to show possible extensions to FizzBuzz logic.
    /// </summary>
    public class WizzStrategy : BaseStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WizzStrategy"/> class.
        /// </summary>
        public WizzStrategy()
            : base(
                i => i == 100,
                OutputConstants.WizzMessage)
        {
        }
    }
}