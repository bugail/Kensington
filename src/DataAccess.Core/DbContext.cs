using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Kensington.DataAccess.Core;

/// <summary>
/// Abstract DbContext
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected DbContext(DbContextOptions options)
        : base(options)
    {
    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        base.OnConfiguring(optionsBuilder);
    }

    /// <summary>
    /// Setup model so that it uses a custom schema
    /// The name of the schema is taken from the name of the DBContext
    /// Example: ProductDbContext produces [product] schema
    /// </summary>
    /// <param name="modelBuilder">The model builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = GetType().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        var schema = GetDefaultSchema();
        modelBuilder.HasDefaultSchema(schema);
    }

    /// <summary>
    /// Gets the default schema name to use for the DbContext.
    /// Defaults to a schema name based on the DbContext, override to provide a custom value.
    /// </summary>
    /// <returns>A <see cref="string"/></returns>
    protected virtual string GetDefaultSchema()
    {
        return GetType()
            .Name
            .Replace("DbContext", string.Empty)
            .ToLower();
    }
}