// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="OutboxMessengerServiceTest.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Kensington.Core.Messages.Outbox;
using Kensington.DataAccess.Interfaces;
using Kensington.Services.Interfaces;
using NSubstitute;

namespace Kensington.Services.UnitTests
{
    [TestFixture]
    public class OutboxMessengerServiceTest
    {
        private IOutboxMessengerService target;
        private IOutboxMessengerRepository repository;

        [SetUp]
        public void TestInitialize()
        {
            this.repository = Substitute.For<IOutboxMessengerRepository>();
            this.target = new OutboxMessengerService(this.repository);
        }

        [Test]
        public async Task SendMessageAsync_NullMessage_ThrowsException()
        {
            // Arrange
            OutboxDtoBase<object> dto = null;

            // Act
            var act = () => this.target.SendMessageAsync(dto);

            // Assert
            await act
                .Should()
                .ThrowAsync<ArgumentNullException>()
                .WithMessage("*Parameter 'message'*");
        }

        [Test]
        public async Task SendMessageAsync_ValidMessage_CallsRepository()
        {
            // Arrange
            var dto = new OutboxDtoBase<object>();

            // Act
            await this.target.SendMessageAsync(dto, CancellationToken.None);

            // Assert
            await repository
                .Received()
                .SendMessageAsync(Arg.Any<OutboxDtoBase<object>>(), CancellationToken.None);
        }
    }
}