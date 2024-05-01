namespace Kensington.Functions.Constants;

public static class SqlDbConstants
{
    /// <summary>
    /// Table name for outbox messages.
    /// </summary>
    public const string TableName = "[dbo].[OutboxMessages]";

    /// <summary>
    /// Generic Cosmos DB Connection String setting used in INteraction History.
    /// </summary>
    public const string ConnectionStringSetting = "SqlConnectionString";
}