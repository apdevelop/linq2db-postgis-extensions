using LinqToDB.Mapping;
using NpgsqlTypes;

namespace LinqToDBPostGisNpgsqlTypes.Tests.Entities
{
    [Table("owm_cities", Schema = "public")]
    public class CityEntity
    {
        [Column("id"), PrimaryKey, NotNull]
        public int Id { get; set; }

        [Column("city_name"), NotNull]
        public string Name { get; set; }

        [Column("geom"), NotNull]
        public PostgisGeometry Geometry { get; set; }
    }
}
