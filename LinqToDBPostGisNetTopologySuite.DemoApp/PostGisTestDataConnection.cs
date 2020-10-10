using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.DemoApp
{
    class PostGisTestDataConnection : DataConnection
    {
        public PostGisTestDataConnection(string connectionString) :
            base("PostgreSQL", connectionString)
        {

        }

        public ITable<OwmCityEntity> OwmCities { get { return GetTable<OwmCityEntity>(); } }
    }

    [Table("owm_cities", Schema = "public")]
    class OwmCityEntity
    {
        [Column("gid"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("city_name"), NotNull]
        public string Name { get; set; }

        [Column("geom")]
        public NTSG Geometry { get; set; }
    }
}