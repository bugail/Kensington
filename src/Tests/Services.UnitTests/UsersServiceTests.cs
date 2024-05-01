// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UsersServiceTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using FluentAssertions;
using Kensington.Core.Results;
using Kensington.DataAccess.Entities;
using Kensington.DataAccess.Interfaces;
using Kensington.DataAccess.Mapping;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Kensington.Services.UnitTests;

[TestFixture]
public class UsersServiceTests
{
    private ILogger<UsersService> logger;
    private IUsersRepository repository;
    private UsersService target;
    private IMapper mapper;

    [SetUp]
    public void Setup()
    {
        var mapperConfiguration = new MapperConfiguration(
            config =>
            {
                config.AddProfile<Mapping.UserProfile>();
                config.AddProfile<UserProfile>();
            });

        mapper = mapperConfiguration.CreateMapper();
        logger = Substitute.For<ILogger<UsersService>>();
        repository = Substitute.For<IUsersRepository>();
        target = new UsersService(repository, mapper, this.logger);
    }

    [Test]
    public async Task GetAsync_UserNotFound_Returns_Null()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = await target.GetAsync(id, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public async Task GetAsync_UserFound_Returns_UserResult()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = GetUserData().Generate();

        repository.GetAsync(id, Arg.Any<CancellationToken>()).Returns(user);

        // Act
        var result = await target.GetAsync(id, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(
            new UserResult
            {
                Firstname = user.Firstname,
                Surname = user.Surname,
                Displayname = user.Displayname
            });
    }

    private static Faker<User> GetUserData()
    {
        return new Faker<User>()
            .RuleFor(u => u.Firstname, f => f.Name.FirstName())
            .RuleFor(u => u.Surname, f => f.Name.LastName())
            .RuleFor(u => u.Displayname, f => f.Internet.UserName());
    }
}