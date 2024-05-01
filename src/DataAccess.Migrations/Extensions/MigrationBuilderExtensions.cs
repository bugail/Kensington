using Microsoft.EntityFrameworkCore.Migrations;

namespace Kensington.DataAccess.Migrations.Extensions;

public static class MigrationBuilderExtensions
{
    public static void EnableChangeTracking(this MigrationBuilder migrationBuilder, string schema, string table)
    {
        migrationBuilder.Sql($"""

                              IF NOT EXISTS (SELECT 1 FROM sys.change_tracking_tables
                                             WHERE object_id = OBJECT_ID('{schema}.{table}'))
                              BEGIN
                                   ALTER TABLE {schema}.{table}
                                   ENABLE CHANGE_TRACKING
                                   WITH (TRACK_COLUMNS_UPDATED = ON)
                              END
                              """);
    }
}