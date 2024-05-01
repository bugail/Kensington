namespace Kensington.DataAccess.Migrations;

public class ServiceMigrations : DbMigrations<KensingtonDbContext>
{
    public ServiceMigrations()
        : base(typeof(ServiceMigrations).Assembly, null)
    {
    }
}