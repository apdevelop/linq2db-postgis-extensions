using LinqToDB.Mapping;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests.Entities
{
    [Table("test_geometry", Schema = "public")]
    public class TestGeometryEntity
    {
        /// <summary>
        /// Identifier (Primary Key)
        /// </summary>
        [Column("id"), PrimaryKey, NotNull]
        public int Id { get; set; }

        /// <summary>
        /// Geometry data
        /// </summary>
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