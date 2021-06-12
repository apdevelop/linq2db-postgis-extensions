using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Overlay Functions.
    /// </summary>
    /// <remarks>
    /// 5.13. Overlay Functions
    /// https://postgis.net/docs/reference.html#Overlay_Functions
    /// </remarks>
    public static class OverlayFunctions
    {
        /// <summary>
        /// Returns geometry clipped by 2D box. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ClipByBox2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="box">Clipping box.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ClipByBox2D", ServerSideOnly = true)]
        public static NTSG STClipByBox2D(this NTSG geometry, NTSG box)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents that part of geometry 1 that does not intersect with geometry 2.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Difference.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Difference geometry.</returns>
        [Sql.Function("ST_Difference", ServerSideOnly = true)]
        public static NTSG STDifference(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents the point set intersection of given geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Intersection.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Difference geometry.</returns>
        [Sql.Function("ST_Intersection", ServerSideOnly = true)]
        public static NTSG STIntersection(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Intersection(geography, geography)

        // TODO: ? ST_MemUnion(geometry set)

        /// <summary>
        /// Fully node set of linestrings using the least possible number of nodes while preserving all of the input ones.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Node.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Node", ServerSideOnly = true)]
        public static NTSG STNode(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Splitting input line by (multi)point, (multi)line or (multi)polygon boundary, a (multi)polygon by line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Split.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="blade">Boundary geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Split", ServerSideOnly = true)]
        public static NTSG STSplit(this NTSG geometry, NTSG blade)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? setof geometry ST_Subdivide

        /// <summary>
        /// Returns geometry that represents the portions of geometry 1 and geometry 2 that do not intersect.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SymDifference.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Difference geometry.</returns>
        [Sql.Function("ST_SymDifference", ServerSideOnly = true)]
        public static NTSG STSymDifference(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        // TODO: STSymDifference(gridSize)

        /// <summary>
        /// Returns union of input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Union.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Union geometry.</returns>
        [Sql.Function("ST_Union", ServerSideOnly = true)]
        public static NTSG STUnion(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        // TODO: STUnion(gridSize)

        /// <summary>
        /// Returns union of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_UnaryUnion.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Union geometry.</returns>
        [Sql.Function("ST_UnaryUnion", ServerSideOnly = true)]
        public static NTSG STUnaryUnion(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns union of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_UnaryUnion.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Union geometry.</returns>
        [Sql.Function("ST_UnaryUnion", ServerSideOnly = true)]
        public static NTSG STUnaryUnion(string geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: STUnaryUnion(gridSize)
    }
}
