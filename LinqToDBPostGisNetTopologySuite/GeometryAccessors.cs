using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Accessors
    /// </summary>
    /// <remarks>
    /// 8.4. Geometry Accessors https://postgis.net/docs/manual-3.0/reference.html#Geometry_Accessors
    /// </remarks>
    public static class GeometryAccessors
    {
        /// <summary>
        /// Returns a LINESTRING representing the exterior ring of the POLYGON geometry. Returns NULL if the geometry is not a polygon.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ExteriorRing.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Exterior ring geometry</returns>
        [Sql.Function("ST_ExteriorRing", ServerSideOnly = true)]
        public static NTSG STExteriorRing(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of points in a geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Number of points</returns>
        [Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int STNPoints(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the minimum bounding box for the supplied geometry, as geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Envelope.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Bounding box geometry</returns>
        [Sql.Function("ST_Envelope", ServerSideOnly = true)]
        public static NTSG STEnvelope(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}