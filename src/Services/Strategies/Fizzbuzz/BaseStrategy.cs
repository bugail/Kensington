// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using Kensington.Services.Interfaces;

namespace Kensington.Services.Strategies.Fizzbuzz
{
    /// <summary>
    /// The base strategy.
    /// </summary>
    public abstract class BaseStrategy : IFizzBuzzStrategy
    {
        private readonly Func<int, bool> criteria;
        private readonly string output;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStrategy"/> class.
        /// </summary>
        /// <param name="criteria">The selection criteria.</param>
        /// <param name="output">The <see cref="string"/> to return.</param>
        public BaseStrategy(
            Func<int, bool> criteria,
            string output)
        {
            this.criteria = criteria;
            this.output = output;
        }

        /// <inheritdoc />
        public string Execute(int value)
        {
            return criteria(value) ? output : string.Empty;
        }
    }
}