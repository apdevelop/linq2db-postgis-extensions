using LinqToDB.Mapping;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite.Tests.Entities
{
    [Table("owm_cities", Schema = "public")]
    public class OwmCityEntity
    {
        [Column("id"), PrimaryKey, NotNull]
        public int Id { get; set; }

        [Column("city_name"), NotNull]
        public string Name { get; set; }

        [Column("geom")]
        public NTSG Geometry { get; set; }
    }
}