using LinqToDB.Mapping;
using NpgsqlTypes;

namespace LinqToDBPostGisNpgsqlTypes.Tests.Entities
{
    [Table(Schema = "public", Name = "postgis_geom")]
    public class PostgisGeometryEntity
    {
        [Column("gid"), PrimaryKey]
        public int Id { get; set; }

        [Column("name"), NotNull]
        public string Name { get; set; }

        [Column("geom"), NotNull]
        public PostgisGeometry Geometry { get; set; }
    }
}
