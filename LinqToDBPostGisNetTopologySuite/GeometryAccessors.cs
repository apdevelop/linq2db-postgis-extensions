using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    // Chapter 8. PostGIS Reference
    // https://postgis.net/docs/manual-3.0/reference.html

    /// <summary>
    /// 8.4. Geometry Accessors
    /// https://postgis.net/docs/manual-3.0/reference.html#Geometry_Accessors
    /// </summary>
    public static class GeometryAccessors
    {
        /// <summary>
        /// Return the number of points in a geometry. Works for all geometries.
        /// https://postgis.net/docs/manual-3.0/ST_NPoints.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Number of points</returns>
        [Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int STNPoints(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}