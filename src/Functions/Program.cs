using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = loggerFactory.CreateLogger<Program>();
try
{
    var host = new HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .ConfigureServices(services =>
        {
            services.Configure<JsonSerializerOptions>(options =>
            {
                options.AllowTrailingCommas = true;
                options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.PropertyNameCaseInsensitive = true;
            });
        })
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    logger.LogCritical("Something Happened: {Message}", ex);
}