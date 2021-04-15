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
        /// Returns TRUE if the Geometries "spatially intersect" in 3D - only for points, linestrings, polygons, polyhedral surface (area)
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DIntersects.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="other">Input other geometry</param>
        /// <returns>If the Geometries "spatially intersect" in 3D - only for points, linestrings, polygons, polyhedral surface (area)</returns>
        [Sql.Function("ST_3DIntersects", ServerSideOnly = true)]
        public static bool? ST3DIntersects(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

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
        public static bool? STContains(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if B intersects the interior of A but not the boundary (or exterior).A does not contain properly itself, but does contain itself
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ContainsProperly.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="other">Input other geometry</param>
        /// <returns>If B intersects the interior of A but not the boundary (or exterior)</returns>
        [Sql.Function("ST_ContainsProperly", ServerSideOnly = true)]
        public static bool? STContainsProperly(this NTSG geometry, NTSG other)
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
        public static bool? STCovers(this NTSG geometry, NTSG other)
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
        public static bool? STCoveredBy(this NTSG geometry, NTSG other)
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
        public static bool? STCrosses(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Given 2 linestrings, returns a number between -3 and 3 denoting what kind of crossing behavior. 0 is no crossing
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineCrossingDirection.html
        /// </remarks>
        /// <param name="geometry">Input given linestring</param>
        /// <param name="other">Input the other linestring</param>
        /// <returns>Crossing behavior number.0 means no cross,-1 cross left,1 cross right,-2 multicross end left,-3 multicross end same first left,3 multicross end same first right</returns>
        [Sql.Function("ST_LineCrossingDirection", ServerSideOnly = true)]
        public static int? STLineCrossingDirection(this NTSG geometry, NTSG other)
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
        public static bool? STDisjoint(this NTSG geometry, NTSG other)
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
        public static bool? STDWithin(this NTSG geometry, NTSG other, double distance)
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
        public static bool? STEquals(this NTSG geometry, NTSG other)
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
        public static bool? STIntersects(this NTSG geometry, NTSG other)
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
        public static bool? STOrderingEquals(this NTSG geometry, NTSG other)
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
        public static bool? STOverlaps(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the geometry is a point and is inside the circle. Returns false otherwise
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointInsideCircle.html
        /// </remarks>
        /// <param name="geometry">Input point geometry</param>
        /// <param name="centerX">Input circle x</param>
        /// <param name="centerY">Input circle y</param>
        /// <param name="radius">Radius of circle</param>
        /// <returns>Is this point inside the circle</returns>
        [Sql.Function("ST_PointInsideCircle", ServerSideOnly = true)]
        public static bool? STPointInsideCircle(this NTSG geometry, double centerX, double centerY, double radius)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Takes geomA, geomB, intersectionMatrix and Returns 1 (TRUE) if this Geometry is spatially related to anotherGeometry, by testing for intersections between the Interior, Boundary and Exterior of the two geometries as specified by the values in the DE-9IM matrix pattern
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Relate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="other">Input geometry other</param>
        /// <param name="intersectionMatrixPattern">Input intersection matrix pattern</param>
        /// <returns>If this Geometry is spatially related to the other geometry</returns>
        [Sql.Function("ST_Relate", ServerSideOnly = true)]
        public static bool? STRelate(this NTSG geometry, NTSG other, string intersectionMatrixPattern)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Takes geomA and geomB and returns the DE-9IM
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Relate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="other">Input other geometry</param>
        /// <returns>DE-9IM between input geometries</returns>
        [Sql.Function("ST_Relate", ServerSideOnly = true)]
        public static string STRelate(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Takes geomA and geomB and returns the DE-9IM
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Relate.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="other">Input other geometry</param>
        /// <param name="BoundaryNodeRule">Boundary node rule (1:OGC/MOD2, 2:Endpoint, 3:MultivalentEndpoint, 4:MonovalentEndpoint)</param>
        /// <returns>DE-9IM between input geometries</returns>
        [Sql.Function("ST_Relate", ServerSideOnly = true)]
        public static string STRelate(this NTSG geometry, NTSG other, int BoundaryNodeRule)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Takes intersectionMatrix and intersectionMatrixPattern and Returns true if the intersectionMatrix satisfies the intersectionMatrixPattern
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_RelateMatch.html
        /// </remarks>
        /// <param name="intersectionMatrix">Input intersectionMatrix</param>
        /// <param name="intersectionMatrixPattern">Input intersectionMatrixPattern</param>
        /// <returns>If the intersectionMatrix satisfies the intersectionMatrixPattern</returns>
        [Sql.Function("ST_RelateMatch", ServerSideOnly = true)]
        public static string STRelateMatch(string intersectionMatrix, string intersectionMatrixPattern)
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
        public static bool? STTouches(this NTSG geometry, NTSG other)
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
        public static bool? STWithin(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// For geometry type returns true if the 3d distance between two objects is within distance_of_srid specified projected units (spatial ref units)
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DDWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <param name="distance">Distance (in SRID units)</param>
        /// <returns>If the 3d distance between two objects is within distanceOfSRID</returns>
        [Sql.Function("ST_3DDWithin", ServerSideOnly = true)]
        public static bool? ST3DDWithin(this NTSG geometry, NTSG other, double distance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the 3D geometries are fully within the specified distance(units defined by SRID) of one another
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DDFullyWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <param name="distance">Distance (in SRID units)</param>
        /// <returns>If the 3d distance between two objects is within distanceOfSRID</returns>
        [Sql.Function("ST_3DDFullyWithin", ServerSideOnly = true)]
        public static bool? ST3DDFullyWithin(this NTSG geometry, NTSG other, double distance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the geometries is fully within the specified distance of one another. The distance is specified in units defined by the spatial reference system of the geometries
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_DFullyWithin.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <param name="distance">Distance (in SRID units)</param>
        /// <returns>If the geometries is fully within the specified distance of one another</returns>
        [Sql.Function("ST_DFullyWithin", ServerSideOnly = true)]
        public static bool? STDFullyWithin(this NTSG geometry, NTSG other, double distance)
        {
            throw new InvalidOperationException();
        }
    }
}