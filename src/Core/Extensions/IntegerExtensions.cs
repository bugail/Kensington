// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IntegerExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Numerics;
using Ardalis.GuardClauses;

namespace Kensington.Core.Extensions
{
    /// <summary>
    /// The integer extensions.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Checks if a value can be divided by a dividing value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="divider">The divider value.</param>
        /// <returns>True if the value can be divided by the divider, False if not.</returns>
        public static bool IsDivisableBy(this int value, int divider)
        {
            return value % divider == 0;
        }

        /// <summary>
        /// Calculates the factorial of a given number.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="int"/>.</returns>
        public static BigInteger Factorial(this int value)
        {
            Guard.Against.Negative(value, nameof(value), "Factorial value must be positive");
            if (value <= 1)
            {
                return 1;
            }

            return value * Factorial(value - 1);
        }
    }
}