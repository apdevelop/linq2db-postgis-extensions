using LinqToDB.Mapping;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests.Entities
{
    [Table("test_geometry", Schema = "public")]
    public class TestGeometryEntity
    {
        [Column("id"), PrimaryKey, NotNull]
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