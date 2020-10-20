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
        /// Returns a LINESTRING representing the exterior ring of the POLYGON geometry. Return NULL if the geometry is not a polygon.
        /// https://postgis.net/docs/manual-3.0/ST_ExteriorRing.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_ExteriorRing", ServerSideOnly = true)]
        public static NTSG STExteriorRing(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

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

        /// <summary>
        /// Returns the minimum bounding box for the supplied geometry, as a geometry.
        /// https://postgis.net/docs/manual-3.0/ST_Envelope.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Bounding box geometry</returns>
        [Sql.Function("ST_Envelope", ServerSideOnly = true)]
        public static NTSG STEnvelope(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}