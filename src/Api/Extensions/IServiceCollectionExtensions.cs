// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IServiceCollectionExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using Kensington.Api.Behaviours;
using Kensington.DataAccess.Extensions;
using Kensington.Handlers.Users.Queries;
using Kensington.Services.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Kensington.Api.Extensions;

/// <summary>
/// The service collection extensions.
/// </summary>
internal static class IServiceCollectionExtensions
{
    /// <summary>
    /// Extension method to add all services to DI.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="connectionString">The DB connection string.</param>
    /// <returns>A <see cref="IServiceCollection"/>.</returns>
    internal static IServiceCollection AddKensingtonServices(this IServiceCollection services, string connectionString)
    {
        return services
            .AddDataAccess(connectionString)
            .AddAutoMapperServices()
            .AddServices()
            .AddMediator()
            .AddFluentValidation();
    }

    private static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        return services.AddAutoMapper(GetAssemblies());
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        foreach (var assembly in GetAssemblies())
        {
            services.AddValidatorsFromAssembly(assembly);
        }

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        return services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserQueryHandler).Assembly))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    private static IEnumerable<Assembly> GetAssemblies()
    {
        var test = Assembly.GetEntryAssembly()
            .GetReferencedAssemblies()
            .Where(x => x.Name.StartsWith("Kensington.", StringComparison.InvariantCulture))
            .Select(Assembly.Load)
            .ToList()
            .Append(Assembly.GetEntryAssembly());

        return test;
    }
}