using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Processing
    /// </summary>
    /// <remarks>
    /// 8.13. Geometry Processing https://postgis.net/docs/manual-3.0/reference.html#Geometry_Processing
    /// </remarks>
    public static class GeometryProcessing
    {
        /// <summary>
        /// Returns geometry that represents all points whose distance from this geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Buffer.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="radius">Buffer radius</param>
        /// <returns>Buffer geometry</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the geometric center of a geometry (the center of mass of the geometry) as a POINT.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Centroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Centroid geometry</returns>
        [Sql.Function("ST_Centroid", ServerSideOnly = true)]
        public static NTSG STCentroid(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the convex hull of given geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ConvexHull.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Convex hull geometry</returns>
        [Sql.Function("ST_ConvexHull", ServerSideOnly = true)]
        public static NTSG STConvexHull(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a geometry that represents that part of geometry 1 that does not intersect with geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Difference.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Difference geometry</returns>
        [Sql.Function("ST_Difference", ServerSideOnly = true)]
        public static NTSG STDifference(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents the point set intersection of given geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Intersection.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Difference geometry</returns>
        [Sql.Function("ST_Intersection", ServerSideOnly = true)]
        public static NTSG STIntersection(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns POINT guaranteed to intersect a surface.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointOnSurface.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Point on surface</returns>
        [Sql.Function("ST_PointOnSurface", ServerSideOnly = true)]
        public static NTSG STPointOnSurface(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents the portions of A and B that do not intersect.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_SymDifference.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Difference geometry</returns>
        [Sql.Function("ST_SymDifference", ServerSideOnly = true)]
        public static NTSG STSymDifference(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns union of given geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Union.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Union geometry</returns>
        [Sql.Function("ST_Union", ServerSideOnly = true)]
        public static NTSG STUnion(this NTSG geometry, NTSG other) // TODO: other variants
        {
            throw new InvalidOperationException();
        }
    }
}