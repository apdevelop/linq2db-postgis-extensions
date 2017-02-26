using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Spatial_Relationships_Measurements

    public static class SpatialRelationshipsAndMeasurements
    {
        /// <summary>
        /// Returns the area of the surface if it is a polygon or multi-polygon. For "geometry" type area is in SRID units.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Area.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Area</returns>
        [LinqToDB.Sql.Function("ST_Area", ServerSideOnly = true)]
        public static double StArea(this PostgisGeometry geom)
        {
            return (double)(object)geom;
        }

        /// <summary>
        /// Returns the geometric center of a geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Centroid.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Geometric center</returns>
        [LinqToDB.Sql.Function("ST_Centroid", ServerSideOnly = true)]
        public static PostgisGeometry StCentroid(this PostgisGeometry geom)
        {
            return geom;
        }

        /// <summary>
        /// Return the length measurement of the boundary of an ST_Surface or ST_MultiSurface value. (Polygon, Multipolygon)
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Perimeter.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Perimeter</returns>
        [LinqToDB.Sql.Function("ST_Perimeter", ServerSideOnly = true)]
        public static double StPerimeter(this PostgisGeometry geom)
        {
            return (double)(object)geom;
        }
    }
}
