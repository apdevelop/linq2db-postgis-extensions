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
        /// Returns geometry that represents all points whose distance from input geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Buffer.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="radius">Buffer radius, in SRS units</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents all points whose distance from input geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Buffer.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="radius">Buffer radius, in SRS units</param>
        /// <param name="style">Buffer style parameters</param> 
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius, string style)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents all points whose distance from input geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Buffer.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="radius">Buffer radius, in SRS units</param>
        /// <param name="segments">Number of segments</param> 
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius, int segments)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Buffer(geography)

        /// <summary>
        /// Returns geometry formed by constituent linework of input geometry. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_BuildArea.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_BuildArea", ServerSideOnly = true)]
        public static NTSG STBuildArea(this NTSG geometry) // TODO: tests
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometric center (center of mass) of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Centroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry (POINT)</returns>
        [Sql.Function("ST_Centroid", ServerSideOnly = true)]
        public static NTSG STCentroid(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_Centroid(geography)

        /// <summary>
        /// Returns geometry clipped by 2D box. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ClipByBox2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="box">Clipping box</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_ClipByBox2D", ServerSideOnly = true)]
        public static NTSG STClipByBox2D(this NTSG geometry, NTSG box)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns concave hull of input geometry. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ConcaveHull.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="targetPercent">Target percent of area of convex hull (0...1)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_ConcaveHull", ServerSideOnly = true)]
        public static NTSG STConcaveHull(this NTSG geometry, double targetPercent) // TODO: test
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns concave hull of input geometry. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_ConcaveHull.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="targetPercent">Target percent of area of convex hull (0...1)</param>
        /// <param name="allowHoles">Allow holes</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_ConcaveHull", ServerSideOnly = true)]
        public static NTSG STConcaveHull(this NTSG geometry, double targetPercent, bool allowHoles) // TODO: test
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns convex hull of input geometry.
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
        /// Converts CIRCULAR STRING to regular LINESTRING or CURVEPOLYGON to POLYGON or MULTISURFACE to MULTIPOLYGON.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_CurveToLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Tolerance value</param>
        /// <param name="toleranceType">Tolerance type</param>
        /// <param name="flags">Output options</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_CurveToLine", ServerSideOnly = true)]
        public static NTSG STCurveToLine(this NTSG geometry, double tolerance, int toleranceType, int flags) // TODO: enums for arguments
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a Delaunay triangulation around the vertices of the input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_DelaunayTriangles.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Tolerance value</param>
        /// <param name="flags">Output options</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_DelaunayTriangles", ServerSideOnly = true)]
        public static NTSG STDelaunayTriangles(this NTSG geometry, double tolerance, int flags) // TODO: enums for arguments
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents that part of geometry 1 that does not intersect with geometry 2.
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
        /// Returns geometry with with flipped X and Y axis of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_FlipCoordinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_FlipCoordinates", ServerSideOnly = true)]
        public static NTSG STFlipCoordinates(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns MULTIPOINT set of pseudo-random points within input geometry
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeneratePoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="numberOfPoints">Number of points to generate</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeneratePoints", ServerSideOnly = true)]
        public static NTSG STGeneratePoints(this NTSG geometry, int numberOfPoints)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns MULTIPOINT set of pseudo-random points within input geometry
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeneratePoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="numberOfPoints">Number of points to generate</param>
        /// <param name="seed">Random seed (should be greater than zero)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeneratePoints", ServerSideOnly = true)]
        public static NTSG STGeneratePoints(this NTSG geometry, int numberOfPoints, int seed)
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