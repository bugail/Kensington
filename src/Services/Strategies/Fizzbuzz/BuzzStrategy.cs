// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BuzzStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Kensington.Core.Constants;
using Kensington.Core.Extensions;

namespace Kensington.Services.Strategies.Fizzbuzz
{
    /// <summary>
    /// The buzz strategy.
    /// </summary>
    public class BuzzStrategy : BaseStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuzzStrategy"/> class.
        /// </summary>
        public BuzzStrategy()
            : base(
                i => i.IsDivisableBy(5), OutputConstants.BuzzMessage)
        {
        }
    }
}