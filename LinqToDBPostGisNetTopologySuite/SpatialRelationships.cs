using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Spatial Relationships
    /// </summary>
    /// <remarks>
    /// 8.11. Spatial Relationships https://postgis.net/docs/manual-3.0/reference.html#Spatial_Relationships
    /// </remarks>
    public static class SpatialRelationships
    {
        /// <summary>
        /// Returns true if geometry 2 is completely inside geometry 1.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Contains.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is contains</returns>
        [Sql.Function("ST_Contains", ServerSideOnly = true)]
        public static bool STContains(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if no point in geometry 2 is outside geometry 1
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Covers.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is covers</returns>
        [Sql.Function("ST_Covers", ServerSideOnly = true)]
        public static bool STCovers(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if no point in geometry 1 is outside geometry 2
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_CoveredBy.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is covered by</returns>
        [Sql.Function("ST_CoveredBy", ServerSideOnly = true)]
        public static bool STCoveredBy(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if intersection of given geometries "spatially cross"
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Crosses.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is crosses</returns>
        [Sql.Function("ST_Crosses", ServerSideOnly = true)]
        public static bool STCrosses(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// If any of the Overlaps, Touches, Within returns true, then the geometries are not spatially disjoint.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Disjoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is disjoints</returns>
        [Sql.Function("ST_Disjoint", ServerSideOnly = true)]
        public static bool STDisjoint(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if geometries are within specified distance of one another.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_DWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <param name="distance">Distance in units defined by the spatial reference system</param>
        /// <returns>Is geometries are within distance</returns>
        [Sql.Function("ST_DWithin", ServerSideOnly = true)]
        public static bool STDWithin(this NTSG geometry, NTSG other, double distance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if given geometries are "spatially equal".
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Equals.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Are spatially equal</returns>
        [Sql.Function("ST_Equals", ServerSideOnly = true)]
        public static bool STEquals(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if two geometries shares any portion of space.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Intersects.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is intersects</returns>
        [Sql.Function("ST_Intersects", ServerSideOnly = true)]
        public static bool STIntersects(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Compares two geometries and returns true if the geometries are equal and their coordinates are in the same order
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_OrderingEquals.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is equal and coordinates are in the same order</returns>
        [Sql.Function("ST_OrderingEquals", ServerSideOnly = true)]
        public static bool STOrderingEquals(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if geometries "spatially overlap".
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Overlaps.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is spatially overlap</returns>
        [Sql.Function("ST_Overlaps", ServerSideOnly = true)]
        public static bool STOverlaps(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the only points in common between geometry 1 and geometry 2 lie in the union of the boundaries of geometry 1 and geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Touches.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is touches</returns>
        [Sql.Function("ST_Touches", ServerSideOnly = true)]
        public static bool STTouches(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if geometry 1 is completely inside geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Within.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is within</returns>
        [Sql.Function("ST_Within", ServerSideOnly = true)]
        public static bool STWithin(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }
    }
}