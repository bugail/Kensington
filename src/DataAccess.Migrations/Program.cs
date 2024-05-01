// See https://aka.ms/new-console-template for more information

namespace Kensington.DataAccess.Migrations;

public static class Program
{
    public static int Main()
        => new ServiceMigrations()
            .ExecuteMigrations();
}