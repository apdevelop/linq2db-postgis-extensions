using LinqToDB;
using LinqToDB.Data;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    public class PostGisTestDataConnection : DataConnection
    {
        public PostGisTestDataConnection(string providerName, string connectionString)
            : base(providerName, connectionString)
        {
            ;
        }

        public ITable<PostgisGeometryEntity> PostgisGeometries { get { return GetTable<PostgisGeometryEntity>(); } }
     }
}
