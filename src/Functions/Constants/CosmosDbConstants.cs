// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CosmosDbConstants.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Kensington.Functions.Constants;

public static class CosmosDbConstants
{
    /// <summary>
    /// Generic Cosmos DB Database name used for Interaction History.
    /// </summary>
    public const string DatabaseName = "TablesDB";

    /// <summary>
    /// Generic Cosmos DB Collection name used for INteraction History.
    /// </summary>
    public const string ContainerName = "OutboxMessages";

    /// <summary>
    /// Generic Cosmos DB Connection String setting used in INteraction History.
    /// </summary>
    public const string ConnectionStringSetting = "CosmosDBChangeFeedConnection";
}