// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IServiceCollectionExtensionsTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Kensington.DataAccess.Extensions;
using Kensington.DataAccess.Interfaces;
using Kensington.DataAccess.Mapping;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Kensington.DataAccess.UnitTests.Extensions;

public class IServiceCollectionExtensionsTests
{
    [Theory]
    [TestCase(typeof(IUsersRepository))]
    [TestCase(typeof(KensingtonDbContext))]
    public void AddDataAccess_RegistersCorrectServices(Type type)
    {
        var services = new ServiceCollection();

        services
            .AddAutoMapper(typeof(UserProfile).Assembly)
            .AddDataAccess("Connection");

        var provider = services.BuildServiceProvider();
        Action act = () => provider.GetRequiredService(type);

        act.Should().NotThrow<InvalidOperationException>();
    }

    [Theory]
    [TestCase("")]
    [TestCase(" ")]
    public void AddDataAccess_InvalidConnectionString_ThrowsException(string connectionString)
    {
        var services = new ServiceCollection();

        Action act = () => services
            .AddAutoMapper(typeof(UserProfile).Assembly)
            .AddDataAccess(connectionString);

        act.Should()
            .Throw<ArgumentException>()
            .WithParameterName("connectionString");
    }

    [Theory]
    public void AddDataAccess_NullConnectionString_ThrowsException()
    {
        var services = new ServiceCollection();

        Action act = () => services
            .AddAutoMapper(typeof(UserProfile).Assembly)
            .AddDataAccess(null);

        act.Should()
            .Throw<ArgumentException>()
            .WithParameterName("connectionString");
    }
}