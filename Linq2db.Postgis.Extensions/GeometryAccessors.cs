using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Accessors

    public static class GeometryAccessors
    {
        /// <summary>
        /// Return the number of points (vertexes) in the geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_NPoints.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Number of points (vertexes)</returns>
        [LinqToDB.Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int StNPoints(this PostgisGeometry geom)
        {
            return (int)(object)geom;
        }

        /// <summary>
        /// Returns the spatial reference identifier for the ST_Geometry as defined in spatial_ref_sys table.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_SRID.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Spatial reference identifier</returns>
        [LinqToDB.Sql.Function("ST_SRID", ServerSideOnly = true)]
        public static int StSrId(this PostgisGeometry geom)
        {
            return (int)(object)geom;
        }

        /// <summary>
        /// Return the X coordinate of the point, or NULL if not available. Input must be a point.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_X.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>X coordinate</returns>
        [LinqToDB.Sql.Function("ST_X", ServerSideOnly = true)]
        public static double StX(this PostgisGeometry geom)
        {
            return (double)(object)geom;
        }

        /// <summary>
        /// Return the Y coordinate of the point, or NULL if not available. Input must be a point.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Y.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Y coordinate</returns>
        [LinqToDB.Sql.Function("ST_Y", ServerSideOnly = true)]
        public static double StY(this PostgisGeometry geom)
        {
            return (double)(object)geom;
        }
    }
}
