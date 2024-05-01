// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IFizzBuzzService.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Kensington.Services.Requests;

namespace Kensington.Services.Interfaces
{
    /// <summary>
    /// The fizz buzz service interface.
    /// </summary>
    public interface IFizzBuzzService
    {
        /// <summary>
        /// Gets the list of FizzBuzz values.
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>A list of <see cref="string"/>.</returns>
        IReadOnlyCollection<string> GetFizzBuzzResults(IEnumerable<int> collection);

        /// <summary>
        /// Gets the list of FizzBuzz values.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>A list of <see cref="string"/>.</returns>
        IReadOnlyCollection<string> GetFizzBuzzResults(FizzBuzzRequest request);
    }
}