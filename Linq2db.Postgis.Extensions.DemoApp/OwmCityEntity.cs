using LinqToDB.Mapping;
using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions.DemoApp
{
    [Table(Schema = "public", Name = "owm_cities")]
    public class OwmCityEntity
    {
        [Column("gid"), PrimaryKey]
        public int Id { get; set; }

        [Column("city_name"), NotNull]
        public string Name { get; set; }

        [Column("geom"), NotNull]
        public PostgisGeometry Geometry { get; set; }
    }
}
