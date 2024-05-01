// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IServiceCollectionExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Ardalis.GuardClauses;
using Kensington.DataAccess.Interfaces;
using Kensington.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kensington.DataAccess.Extensions;

/// <summary>
/// The IServiceCollection extension methods.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds all services needed for data acccess.
    /// </summary>
    /// <param name="services">Teh service collection.</param>
    /// <param name="connectionString">The connection string.</param>
    /// <returns>A <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        string connectionString)
    {
        Guard.Against.NullOrWhiteSpace(connectionString, nameof(connectionString));

        services.AddDbContext<KensingtonDbContext>(
            options =>
            options.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly("Kensington.DataAccess.Migrations")));

        return services
            .AddScoped<IOutboxMessengerRepository, OutboxMessengerRepository>()
            .AddScoped<IUsersRepository, UsersRepository>();
    }
}