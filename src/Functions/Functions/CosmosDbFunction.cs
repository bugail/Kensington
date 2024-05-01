using Kensington.DataAccess.Entities;
using Kensington.Functions.Constants;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Kensington.Functions.Functions;

public class CosmosDbFunction
{
    private readonly ILogger<CosmosDbFunction> logger;

    public CosmosDbFunction(ILogger<CosmosDbFunction> logger)
    {
        this.logger = logger;
    }

    [Function("SendEmailCosmos")]
    public void RunCosmos(
        [CosmosDBTrigger(
            databaseName: CosmosDbConstants.DatabaseName,
            containerName: CosmosDbConstants.ContainerName,
            Connection = CosmosDbConstants.ConnectionStringSetting,
            LeaseContainerName = "leases",
            CreateLeaseContainerIfNotExists = true)]
        IReadOnlyList<OutboxMessage> documents)
    {
        if (documents != null && documents.Count > 0)
        {
            logger.LogInformation("Documents modified " + documents.Count);
        }
    }
}