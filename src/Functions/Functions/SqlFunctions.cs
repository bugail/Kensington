// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SqlFunctions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Ardalis.GuardClauses;
using Kensington.DataAccess.Entities;
using Kensington.Functions.Constants;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace Kensington.Functions.Functions;

public class SqlFunctions
{
    private readonly ILogger<SqlFunctions> logger;

    public SqlFunctions(ILogger<SqlFunctions> logger)
    {
        this.logger = logger;
    }

    [Function(nameof(RunSqlTrigger))]
    public void RunSqlTrigger([SqlTrigger(
            SqlDbConstants.TableName,
            SqlDbConstants.ConnectionStringSetting)]
        IReadOnlyList<SqlChange<OutboxMessage>> messages)
    {
        Guard.Against.NullOrEmpty(messages);

        foreach (var change in messages)
        {
            var doc = change.Item;

            logger.LogInformation("Message: ID: {ID}, Type:{Type}", doc.Id, doc.Type);
        }
    }
}