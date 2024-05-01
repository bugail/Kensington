using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kensington.DataAccess.Migrations
{
    /// <summary>
    /// Provides functionality for creating new data migrations for a given DbContext
    /// as well as applying the migrations
    /// </summary>
    /// <typeparam name="TContext">The DB Context.</typeparam>
    public abstract class DbMigrations<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : DbContext
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<DbMigrations<TContext>> logger;
        private readonly Assembly migrationsAssembly;
        private readonly object[] customDependencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbMigrations{TContext}"/> class.
        /// </summary>
        /// <param name="migrationsAssembly">Assembly where the data migrations are located</param>
        /// <param name="customDependencies">Provide any custom dependencies needed to instantiate TContext</param>
        protected DbMigrations(
            Assembly migrationsAssembly,
            params object[] customDependencies)
            : this(
                  new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build(),
                  migrationsAssembly)
        {
            this.customDependencies = customDependencies;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbMigrations{TContext}"/> class.
        /// Initializes DbMigrations with console logs and configuration
        /// </summary>
        /// <param name="configuration">Seeks value for DataMigrations:LogLevel. Defaults to LogLevel.Information if not found</param>
        /// <param name="migrationsAssembly">Assembly where the data migrations are located</param>
        /// <param name="logger">The logger.</param>
        protected DbMigrations(
            IConfiguration configuration,
            Assembly migrationsAssembly,
            ILogger<DbMigrations<TContext>> logger = null)
        {
            this.migrationsAssembly = migrationsAssembly;

            var logLevel = configuration.GetValue<LogLevel?>("DataMigrations:LogLevel")
                ?? LogLevel.Information;

            loggerFactory =
                LoggerFactory
                    .Create(builder =>
                        builder
                            .AddConsole()
                            .SetMinimumLevel(logLevel));

            this.logger = logger ?? loggerFactory
                .CreateLogger<DbMigrations<TContext>>();
            Configuration = configuration;
        }

        /// <summary>
        /// Gets a Exposes the entire configuration
        /// </summary>
        /// <returns>A <see cref="IConfiguration"/></returns>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Executes Migrations for given DbContext
        /// </summary>
        /// <returns>An <see cref="int"/></returns>
        public int ExecuteMigrations()
        {
            var contextName = typeof(TContext).Name;
            logger.LogInformation($"Started migrating {contextName}...");

            using var ctx = CreateDbContext([]);
            var timeout = TimeSpan.FromHours(4);
            ctx.Database.SetCommandTimeout(timeout);
            ctx.Database.Migrate();

            logger.LogInformation($"Finished migrating {contextName}.");

            return 0;
        }

        /// <summary>
        /// Creates instance of DbContext using SqlServer.
        /// Expects Migration files to be in the same assembly as Assembly.GetEntryAssembly()
        /// </summary>
        /// <param name="args">Needed by EF for Add-Migration command</param>
        /// <returns>Instance of TContext</returns>
        public TContext CreateDbContext(string[] args)
        {
            var builder = typeof(DbContextOptionsBuilder<>);
            Type[] typeArgs = { typeof(TContext) };
            var genericBuilder = builder.MakeGenericType(typeArgs);

            var connectionString = ReadConnectionString();

            var serviceName = GetConfigurationKey<TContext>();
            var schemaName = serviceName.ToLowerInvariant();

            var optionsBuilder = Activator.CreateInstance(genericBuilder) as DbContextOptionsBuilder;
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .UseSqlServer(
                    connectionString,
                    opt =>
                    {
                        opt.MigrationsAssembly(migrationsAssembly.GetName().Name);
                        opt.MigrationsHistoryTable($"__{serviceName}MigrationsHistory", schemaName);
                        opt.EnableRetryOnFailure();
                    });

            if (customDependencies?.Length == 0)
            {
                return Activator.CreateInstance(
                    typeof(TContext),
                    (dynamic)optionsBuilder.Options);
            }

            return Activator.CreateInstance(
                typeof(TContext),
                (dynamic)optionsBuilder.Options,
                customDependencies);
        }

        /// <summary>
        /// Seeks for configuration based on type name, removing 'DbContext' from it
        /// <example>ComplaintsDbContext would require configuration called Complaints</example>
        /// </summary>
        /// <returns>A <see cref="string"/></returns>
        protected string ReadConnectionString()
        {
            var key = GetConfigurationKey<TContext>();
            var fallbackKey = "Kensington";
            var connectionString = Configuration.GetConnectionString(key)
                                   ?? Configuration.GetConnectionString(fallbackKey);

            if (string.IsNullOrEmpty(connectionString))
            {
                logger.LogError("Unable to load connection string named " +
                                $"{key} or {fallbackKey} for {typeof(TContext)}");
                Environment.Exit(-1);
            }

            return connectionString;
        }

        private static string GetConfigurationKey<TDbContext>()
            where TDbContext : DbContext
        {
            return typeof(TDbContext)
                .Name
                .Replace(
                    "DbContext",
                    string.Empty,
                    StringComparison.InvariantCultureIgnoreCase);
        }
    }
}