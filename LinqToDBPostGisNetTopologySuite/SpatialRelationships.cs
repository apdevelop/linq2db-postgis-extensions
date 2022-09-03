using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Spatial Relationships.
    /// </summary>
    /// <remarks>
    /// 5.11. Spatial Relationships 
    /// https://postgis.net/docs/reference.html#Spatial_Relationships
    /// </remarks>
    public static class SpatialRelationships
    {
#pragma warning disable IDE0060
        #region 5.11.1. Topological Relationships
        /// <summary>
        /// Checks if input geometries spatially intersects (overlaps, touches, within) in 3D.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DIntersects.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True, if input geometries spatially intersect.</returns>
        [Sql.Function("ST_3DIntersects", ServerSideOnly = true)]
        public static bool? ST3DIntersects(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries spatially intersects (overlaps, touches, within) in 3D.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DIntersects.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True, if input geometries spatially intersect.</returns>
        [Sql.Function("ST_3DIntersects", ServerSideOnly = true)]
        public static bool? ST3DIntersects(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometry 2 is completely inside input geometry 1.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Contains.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometry 2 is completely inside input geometry 1.</returns>
        [Sql.Function("ST_Contains", ServerSideOnly = true)]
        public static bool? STContains(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometry 2 intersects the interior of input geometry 1 but not the boundary (or exterior).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ContainsProperly.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometry 2 intersects the interior of input geometry 1 but not the boundary (or exterior).</returns>
        [Sql.Function("ST_ContainsProperly", ServerSideOnly = true)]
        public static bool? STContainsProperly(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometry 2 intersects the interior of input geometry 1 but not the boundary (or exterior).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ContainsProperly.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometry 2 intersects the interior of input geometry 1 but not the boundary (or exterior).</returns>
        [Sql.Function("ST_ContainsProperly", ServerSideOnly = true)]
        public static bool? STContainsProperly(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if no point in geometry 2 is outside geometry 1.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Covers.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if no point in geometry 2 is outside geometry 1.</returns>
        [Sql.Function("ST_Covers", ServerSideOnly = true)]
        public static bool? STCovers(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if no point in geometry 2 is outside geometry 1.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Covers.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if no point in geometry 2 is outside geometry 1.</returns>
        [Sql.Function("ST_Covers", ServerSideOnly = true)]
        public static bool? STCovers(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if no point in geometry 1 is outside geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CoveredBy.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if no point in geometry 1 is outside geometry 2.</returns>
        [Sql.Function("ST_CoveredBy", ServerSideOnly = true)]
        public static bool? STCoveredBy(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if no point in geometry 1 is outside geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CoveredBy.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if no point in geometry 1 is outside geometry 2.</returns>
        [Sql.Function("ST_CoveredBy", ServerSideOnly = true)]
        public static bool? STCoveredBy(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if intersection of given geometries "spatially cross".
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Crosses.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if intersection of given geometries "spatially cross".</returns>
        [Sql.Function("ST_Crosses", ServerSideOnly = true)]
        public static bool? STCrosses(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if intersection of given geometries "spatially cross".
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Crosses.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if intersection of given geometries "spatially cross".</returns>
        [Sql.Function("ST_Crosses", ServerSideOnly = true)]
        public static bool? STCrosses(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Computes kind of crossing behavior.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineCrossingDirection.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 (LineString).</param>
        /// <param name="other">Input geometry 2 (LineString).</param>
        /// <returns>Crossing behavior number. 0 means no cross, -1 cross left, 1 cross right, -2 multicross end left, -3 multicross end same first left, 3 multicross end same first right.</returns>
        [Sql.Function("ST_LineCrossingDirection", ServerSideOnly = true)]
        public static int? STLineCrossingDirection(this NTSG geometry, NTSG other) => throw new InvalidOperationException(); // TODO: enum for result

        /// <summary>
        /// Computes kind of crossing behavior.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineCrossingDirection.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 (LineString).</param>
        /// <param name="other">Input geometry 2 (LineString).</param>
        /// <returns>Crossing behavior number. 0 means no cross, -1 cross left, 1 cross right, -2 multicross end left, -3 multicross end same first left, 3 multicross end same first right.</returns>
        [Sql.Function("ST_LineCrossingDirection", ServerSideOnly = true)]
        public static int? STLineCrossingDirection(string geometry, string other) => throw new InvalidOperationException(); // TODO: enum for result

        /// <summary>
        /// Checks if input geometries are spatially disjoint.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Disjoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True, if geometries are spatially disjoint.</returns>
        [Sql.Function("ST_Disjoint", ServerSideOnly = true)]
        public static bool? STDisjoint(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are spatially disjoint.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Disjoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True, if geometries are spatially disjoint.</returns>
        [Sql.Function("ST_Disjoint", ServerSideOnly = true)]
        public static bool? STDisjoint(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are spatially equal.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Equals.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometries are spatially equal.</returns>
        [Sql.Function("ST_Equals", ServerSideOnly = true)]
        public static bool? STEquals(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are spatially equal.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Equals.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometries are spatially equal.</returns>
        [Sql.Function("ST_Equals", ServerSideOnly = true)]
        public static bool? STEquals(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries shares any portion of space.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Intersects.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1 (or geography).</param>
        /// <param name="other">Input geometry 2 (or geography).</param>
        /// <returns>True if input geometries shares any portion of space.</returns>
        [Sql.Function("ST_Intersects", ServerSideOnly = true)]
        public static bool? STIntersects(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries shares any portion of space.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Intersects.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometries shares any portion of space.</returns>
        [Sql.Function("ST_Intersects", ServerSideOnly = true)]
        public static bool? STIntersects(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are equal and their coordinates are in the same order.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_OrderingEquals.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometries are equal and their coordinates are in the same order.</returns>
        [Sql.Function("ST_OrderingEquals", ServerSideOnly = true)]
        public static bool? STOrderingEquals(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are equal and their coordinates are in the same order.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_OrderingEquals.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if input geometries are equal and their coordinates are in the same order.</returns>
        [Sql.Function("ST_OrderingEquals", ServerSideOnly = true)]
        public static bool? STOrderingEquals(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are spatially overlap.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Overlaps.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Returns true if geometries spatially overlap.</returns>
        [Sql.Function("ST_Overlaps", ServerSideOnly = true)]
        public static bool? STOverlaps(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are spatially overlap.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Overlaps.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Returns true if geometries spatially overlap.</returns>
        [Sql.Function("ST_Overlaps", ServerSideOnly = true)]
        public static bool? STOverlaps(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Tests and evaluates the spatial (topological) relationship between input geometries, as defined by the Dimensionally Extended 9-Intersection Model (DE-9IM).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Relate.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="intersectionMatrixPattern">Intersection matrix pattern (DE-9IM).</param>
        /// <returns>True if input geometry 1 is spatially related to the geometry 2.</returns>
        [Sql.Function("ST_Relate", ServerSideOnly = true)]
        public static bool? STRelate(this NTSG geometry, NTSG other, string intersectionMatrixPattern) => throw new InvalidOperationException();

        /// <summary>
        /// Computes DE-9IM matrix for the spatial relationship between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Relate.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>The DE-9IM matrix string for the spatial relationship between input geometries.</returns>
        [Sql.Function("ST_Relate", ServerSideOnly = true)]
        public static string STRelate(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Computes DE-9IM matrix for the spatial relationship between input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Relate.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="boundaryNodeRule">Boundary node rule (1:OGC/MOD2, 2:Endpoint, 3:MultivalentEndpoint, 4:MonovalentEndpoint).</param>
        /// <returns>The DE-9IM matrix string for the spatial relationship between input geometries.</returns>
        [Sql.Function("ST_Relate", ServerSideOnly = true)]
        public static string STRelate(this NTSG geometry, NTSG other, int boundaryNodeRule) => throw new InvalidOperationException(); // TODO: enum/const for boundaryNodeRule

        /// <summary>
        /// Tests if the <paramref name="intersectionMatrix"/> value satisfies an <paramref name="intersectionMatrixPattern"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RelateMatch.html
        /// </remarks>
        /// <param name="intersectionMatrix">Intersection matrix (Dimensionally Extended 9-Intersection Model (DE-9IM)).</param>
        /// <param name="intersectionMatrixPattern">Intersection matrix pattern.</param>
        /// <returns>True, if the <paramref name="intersectionMatrix"/> satisfies the <paramref name="intersectionMatrixPattern"/></returns>
        [Sql.Function("ST_RelateMatch", ServerSideOnly = true)]
        public static bool? STRelateMatch(string intersectionMatrix, string intersectionMatrixPattern) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if the only points in common between geometry 1 and geometry 2 lie in the union of the boundaries of geometry 1 and geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Touches.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if the only points in common between geometry 1 and geometry 2 lie in the union of the boundaries of geometry 1 and geometry 2.</returns>
        [Sql.Function("ST_Touches", ServerSideOnly = true)]
        public static bool? STTouches(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if the only points in common between geometry 1 and geometry 2 lie in the union of the boundaries of geometry 1 and geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Touches.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if the only points in common between geometry 1 and geometry 2 lie in the union of the boundaries of geometry 1 and geometry 2.</returns>
        [Sql.Function("ST_Touches", ServerSideOnly = true)]
        public static bool? STTouches(string geometry, string other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometry 1 is completely inside input geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Within.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if geometry 1 is completely inside geometry 2.</returns>
        [Sql.Function("ST_Within", ServerSideOnly = true)]
        public static bool? STWithin(this NTSG geometry, NTSG other) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometry 1 is completely inside input geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Within.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>True if geometry 1 is completely inside geometry 2.</returns>
        [Sql.Function("ST_Within", ServerSideOnly = true)]
        public static bool? STWithin(string geometry, string other) => throw new InvalidOperationException();
        #endregion 5.11.1. Topological Relationships

        #region 5.11.2. Distance Relationships
        /// <summary>
        /// Checks if the 3D distance between input geometries is within given <paramref name="distance"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DDWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True, if the 3D distance between input geometries is within <paramref name="distance"/>.</returns>
        [Sql.Function("ST_3DDWithin", ServerSideOnly = true)]
        public static bool? ST3DDWithin(this NTSG geometry, NTSG other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if the 3D distance between input geometries is within given <paramref name="distance"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DDWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True, if the 3D distance between input geometries is within <paramref name="distance"/>.</returns>
        [Sql.Function("ST_3DDWithin", ServerSideOnly = true)]
        public static bool? ST3DDWithin(string geometry, string other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are fully within the given 3D <paramref name="distance"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DDFullyWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True, if input geometries are fully within the given <paramref name="distance"/>.</returns>
        [Sql.Function("ST_3DDFullyWithin", ServerSideOnly = true)]
        public static bool? ST3DDFullyWithin(this NTSG geometry, NTSG other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are fully within the given 3D <paramref name="distance"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DDFullyWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True, if input geometries are fully within the given <paramref name="distance"/>.</returns>
        [Sql.Function("ST_3DDFullyWithin", ServerSideOnly = true)]
        public static bool? ST3DDFullyWithin(string geometry, string other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries is fully within the specified <paramref name="distance"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DFullyWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True if the geometries is fully within the specified <paramref name="distance"/>.</returns>
        [Sql.Function("ST_DFullyWithin", ServerSideOnly = true)]
        public static bool? STDFullyWithin(this NTSG geometry, NTSG other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries is fully within the specified <paramref name="distance"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DFullyWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True if the geometries is fully within the specified <paramref name="distance"/>.</returns>
        [Sql.Function("ST_DFullyWithin", ServerSideOnly = true)]
        public static bool? STDFullyWithin(string geometry, string other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are within specified <paramref name="distance"/> of one another.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True, if input geometries are within specified <paramref name="distance"/> of one another.</returns>
        [Sql.Function("ST_DWithin", ServerSideOnly = true)]
        public static bool? STDWithin(this NTSG geometry, NTSG other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Checks if input geometries are within specified <paramref name="distance"/> of one another.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <param name="distance">Distance (in SRS units).</param>
        /// <returns>True, if input geometries are within specified <paramref name="distance"/> of one another.</returns>
        [Sql.Function("ST_DWithin", ServerSideOnly = true)]
        public static bool? STDWithin(string geometry, string other, double distance) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if the geometry is a point and is inside the circle. Returns false otherwise
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointInsideCircle.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <param name="centerX">Input circle center X coordinate.</param>
        /// <param name="centerY">Input circle center Y coordinate.</param>
        /// <param name="radius">Radius of circle.</param>
        /// <returns>True if the input <paramref name="geometry"/> is a Point and is inside the circle, false otherwise.</returns>
        [Sql.Function("ST_PointInsideCircle", ServerSideOnly = true)]
        public static bool? STPointInsideCircle(this NTSG geometry, double centerX, double centerY, double radius) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if the geometry is a point and is inside the circle. Returns false otherwise
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointInsideCircle.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <param name="centerX">Input circle center X coordinate.</param>
        /// <param name="centerY">Input circle center Y coordinate.</param>
        /// <param name="radius">Radius of circle.</param>
        /// <returns>True if the input <paramref name="geometry"/> is a Point and is inside the circle, false otherwise.</returns>
        [Sql.Function("ST_PointInsideCircle", ServerSideOnly = true)]
        public static bool? STPointInsideCircle(string geometry, double centerX, double centerY, double radius) => throw new InvalidOperationException();
        #endregion 5.11.2. Distance Relationships
#pragma warning restore IDE0060
    }
}
