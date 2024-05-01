// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="TransactionBehaviour.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Extensions;
using Kensington.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Kensington.Api.Behaviours;

using ExecutionStrategyExtensions = Microsoft.EntityFrameworkCore.ExecutionStrategyExtensions;

/// <summary>The transaction behaviour class.</summary>
/// <typeparam name="TRequest">The T request.</typeparam>
/// <typeparam name="TResponse">The T response.</typeparam>
public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>The logger.</summary>
    private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> logger;

    /// <summary>The db context.</summary>
    private readonly KensingtonDbContext dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionBehaviour{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="dbContext">The application database context.</param>
    /// <param name="logger">The logger.</param>
    public TransactionBehaviour(
        KensingtonDbContext dbContext,
        ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
    {
        this.dbContext = dbContext ?? throw new ArgumentException(nameof(KensingtonDbContext));
        this.logger = logger ?? throw new ArgumentException(nameof(ILogger));
    }

    /// <inheritdoc/>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = default(TResponse);
        var typeName = request.GetGenericTypeName();

        try
        {
            if (dbContext.HasActiveTransaction)
            {
                return await next();
            }

            var strategy = dbContext.Database.CreateExecutionStrategy();

            await ExecutionStrategyExtensions.ExecuteAsync(strategy, async () =>
            {
                using (var transaction = await dbContext.BeginTransactionAsync())
                using (LogContext.PushProperty("TransactionContext", transaction.TransactionId))
                {
                    logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})", transaction.TransactionId, typeName, request);

                    response = await next();

                    logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

                    await dbContext.CommitTransactionAsync(transaction);
                }
            });

            return response;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

            throw;
        }
    }
}