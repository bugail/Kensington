// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IFizzBuzzStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Kensington.Services.Interfaces
{
    /// <summary>
    /// The fizz buzz strategy interface.
    /// </summary>
    public interface IFizzBuzzStrategy
    {
        /// <summary>
        /// Executes the strategy and returns the result.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>A <see cref="string"/>.</returns>
        string Execute(int value);
    }
}