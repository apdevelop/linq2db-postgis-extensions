using LinqToDB.Mapping;
using NpgsqlTypes;

namespace LinqToDBPostGisNpgsqlTypes.Tests.Entities
{
    [Table("test_geometry", Schema = "public")]
    public class PostgisGeometryEntity
    {
        [Column("id"), PrimaryKey, NotNull]
        public int Id { get; set; }

        [Column("geom"), Nullable]
        public PostgisGeometry Geometry { get; set; }
    }
}