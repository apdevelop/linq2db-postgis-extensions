using System.Configuration;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    abstract class TestsBase
    {
        public static readonly int SRID_WGS_84 = 4326;

        public static readonly int SRID_WGS84_Web_Mercator = 3857;

        public PostGisTestDataConnection GetDbConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["postgistest"];
            return new PostGisTestDataConnection(connectionString.ProviderName, connectionString.ConnectionString);
        }
    }
}
