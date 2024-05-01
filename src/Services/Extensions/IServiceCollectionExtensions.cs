// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Kensington.Services.Interfaces;
using Kensington.Services.Strategies.Fizzbuzz;
using Microsoft.Extensions.DependencyInjection;

namespace Kensington.Services.Extensions
{
    /// <summary>
    /// The service collection extensions.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>A <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddFizzBuzzServices()
                .AddScoped<IOutboxMessengerService, OutboxMessengerService>()
                .AddScoped<IUsersService, UsersService>();
        }

        private static IServiceCollection AddFizzBuzzServices(this IServiceCollection services)
        {
            services.AddScoped<IFizzBuzzStrategy, FizzStrategy>();
            services.AddScoped<IFizzBuzzStrategy, BuzzStrategy>();
            services.AddScoped<IFizzBuzzStrategy, WizzStrategy>();
            services.AddScoped<IFizzBuzzService, FizzBuzzService>();

            return services;
        }
    }
}