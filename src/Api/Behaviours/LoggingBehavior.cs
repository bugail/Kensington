// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LoggingBehavior.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Kensington.Api.Behaviours
{
    /// <summary>
    /// Logging behaviour for commands.
    /// </summary>
    /// <typeparam name="TRequest">The command.</typeparam>
    /// <typeparam name="TResponse">The response.</typeparam>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => this.logger = logger;

        /// <inheritdoc/>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var commandName = request.GetGenericTypeName();

            logger.LogInformation("----- Handling command {CommandName} ", commandName);
            logger.LogDebug("----- Handling command {CommandName} ({@Command})", commandName, request);

            var response = await next();

            logger.LogInformation("----- Command {CommandName} handled", commandName);
            logger.LogDebug("----- Command {CommandName} handled - response: {@Response}", commandName, response);

            return response;
        }
    }
}