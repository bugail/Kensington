// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzService.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ardalis.GuardClauses;
using Kensington.Services.Interfaces;
using Kensington.Services.Requests;
using Microsoft.Extensions.Logging;

namespace Kensington.Services
{
    /// <summary>
    /// The fizzbuzz service.
    /// </summary>
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IFizzBuzzStrategy> strategies;
        private readonly ILogger<FizzBuzzService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzService"/> class.
        /// </summary>
        /// <param name="strategies">A list of <see cref="IFizzBuzzStrategy"/></param>
        /// <param name="logger">The logger.</param>
        public FizzBuzzService(IEnumerable<IFizzBuzzStrategy> strategies, ILogger<FizzBuzzService> logger)
        {
            this.strategies = strategies;
            this.logger = logger;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<string> GetFizzBuzzResults(IEnumerable<int> collection)
        {
            Guard.Against.NullOrEmpty(collection, nameof(collection));

            var list = new List<string>();
            var value = string.Empty;

            foreach (var item in collection)
            {
                var builder = new StringBuilder();

                foreach (var strategy in strategies)
                {
                    builder.Append(strategy.Execute(item));
                }

                value = builder.ToString();

                list.Add(value == string.Empty ? item.ToString() : value);
            }

            return list;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<string> GetFizzBuzzResults(FizzBuzzRequest request)
        {
            Guard.Against.Null(request, nameof(request));

            var list = Enumerable.Range(Convert.ToInt32(request.Start), Convert.ToInt32(request.End)).ToList();
            return this.GetFizzBuzzResults(list);
        }
    }
}