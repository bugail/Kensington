// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzRequest.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Kensington.Services.Requests
{
    /// <summary>
    /// The fizzbuzz request.
    /// </summary>
    public class FizzBuzzRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzRequest"/> class.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        public FizzBuzzRequest(string start, string end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Gets the start value.
        /// </summary>
        public string Start { get; }

        /// <summary>
        /// Gets the end value.
        /// </summary>
        public string End { get; }
    }
}