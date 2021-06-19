using LinqToDB.Mapping;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests.Entities
{
    [Table("test_geography", Schema = "public")]
    public class TestGeographyEntity
    {
        /// <summary>
        /// Identifier (Primary Key).
        /// </summary>
        [Column("id"), PrimaryKey, NotNull]
        public int Id { get; set; }

        /// <summary>
        /// Geography data.
        /// </summary>
        [Column("geog"), Nullable]
        public NTSG Geography { get; set; }

        public TestGeographyEntity()
        {

        }

        public TestGeographyEntity(int id, NTSG geography)
        {
            this.Id = id;
            this.Geography = geography;
        }
    }
}
