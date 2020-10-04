using LinqToDB;
using LinqToDB.Data;

using Linq2db.Postgis.Extensions.Tests.Entities;

namespace Linq2db.Postgis.Extensions.Tests
{
    public class PostGisTestDataConnection : DataConnection
    {
        public PostGisTestDataConnection(string providerName, string connectionString)
            : base(providerName, connectionString)
        {

        }

        public ITable<PostgisGeometryEntity> PostgisGeometries { get { return GetTable<PostgisGeometryEntity>(); } }

        public ITable<PolygonEntity> Polygons { get { return GetTable<PolygonEntity>(); } }

        public ITable<OwmCityEntity> OwmCities { get { return GetTable<OwmCityEntity>(); } }
     }
}
