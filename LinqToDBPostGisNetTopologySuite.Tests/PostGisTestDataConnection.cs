using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    public class PostGisTestDataConnection : DataConnection
    {
        public PostGisTestDataConnection(string connectionString) :
            base("PostgreSQL", connectionString)
        {

        }

        public ITable<OwmCityEntity> OwmCities { get { return GetTable<OwmCityEntity>(); } }

        public ITable<TestGeometryEntity> TestGeometries { get { return GetTable<TestGeometryEntity>(); } }
    }

    [Table("owm_cities", Schema = "public")]
    public class OwmCityEntity
    {
        [Column("gid"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("city_name"), NotNull]
        public string Name { get; set; }

        [Column("geom")]
        public NTSG Geometry { get; set; }
    }

    [Table("test_geometry", Schema = "public")]
    public class TestGeometryEntity
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("geom"), Nullable]
        public NTSG Geometry { get; set; }

        public TestGeometryEntity()
        {

        }

        public TestGeometryEntity(int id, NTSG geometry)
        {
            this.Id = id;
            this.Geometry = geometry;
        }
    }
}