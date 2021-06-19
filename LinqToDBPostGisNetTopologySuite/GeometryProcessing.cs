using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Processing.
    /// </summary>
    /// <remarks>
    /// 5.14. Geometry Processing
    /// https://postgis.net/docs/reference.html#Geometry_Processing
    /// </remarks>
    public static class GeometryProcessing
    {
        /// <summary>
        /// Returns geometry that represents all points whose distance from input geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Buffer.html
        /// </remarks>
        /// <param name="geometry">Input geometry (or geography).</param>
        /// <param name="radius">Buffer radius, in SRS units.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents all points whose distance from input geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Buffer.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="radius">Buffer radius, in SRS units.</param>
        /// <param name="style">Buffer style parameters.</param> 
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius, string style)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents all points whose distance from input geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Buffer.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="radius">Buffer radius, in SRS units.</param>
        /// <param name="segments">Number of segments.</param> 
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius, int segments)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry formed by constituent linework of input geometry. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_BuildArea.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_BuildArea", ServerSideOnly = true)]
        public static NTSG STBuildArea(this NTSG geometry) // TODO: tests
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometric center (center of mass) of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Centroid.html
        /// </remarks>
        /// <param name="geometry">Input geometry (or geography).</param>
        /// <returns>Geometric center (Point).</returns>
        [Sql.Function("ST_Centroid", ServerSideOnly = true)]
        public static NTSG STCentroid(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometric center (center of mass) of input <paramref name="geography"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Centroid.html
        /// </remarks>
        /// <param name="geography">Input geography.</param>
        /// <param name="useSpheroid">Use spheroid (true) of simple sphere (false).</param>
        /// <returns>Geometric center (Point).</returns>
        [Sql.Function("ST_Centroid", ServerSideOnly = true)]
        public static NTSG STCentroid(this NTSG geography, bool useSpheroid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns concave hull of input geometry. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ConcaveHull.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="targetPercent">Target percent of area of convex hull (0...1).</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ConcaveHull", ServerSideOnly = true)]
        public static NTSG STConcaveHull(this NTSG geometry, double targetPercent) // TODO: test
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns concave hull of input geometry. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ConcaveHull.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="targetPercent">Target percent of area of convex hull (0...1).</param>
        /// <param name="allowHoles">Allow holes.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ConcaveHull", ServerSideOnly = true)]
        public static NTSG STConcaveHull(this NTSG geometry, double targetPercent, bool allowHoles) // TODO: test
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns convex hull of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ConvexHull.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Convex hull geometry.</returns>
        [Sql.Function("ST_ConvexHull", ServerSideOnly = true)]
        public static NTSG STConvexHull(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a Delaunay triangulation around the vertices of the input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_DelaunayTriangles.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Tolerance value.</param>
        /// <param name="flags">Output options.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_DelaunayTriangles", ServerSideOnly = true)]
        public static NTSG STDelaunayTriangles(this NTSG geometry, double tolerance, int flags) // TODO: enums for arguments
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns MULTIPOINT set of pseudo-random points within input geometry
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeneratePoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="numberOfPoints">Number of points to generate.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeneratePoints", ServerSideOnly = true)]
        public static NTSG STGeneratePoints(this NTSG geometry, int numberOfPoints)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns MULTIPOINT set of pseudo-random points within input geometry
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeneratePoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="numberOfPoints">Number of points to generate.</param>
        /// <param name="seed">Random seed (should be greater than zero).</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeneratePoints", ServerSideOnly = true)]
        public static NTSG STGeneratePoints(this NTSG geometry, int numberOfPoints, int seed)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns approximate geometric median of input MultiPoint geometry using the Weiszfeld algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometricMedian.html
        /// </remarks>
        /// <param name="geometry">Input geometry (MultiPoint).</param>
        /// <param name="tolerance">Tolerance value.</param>
        /// <param name="maxIterations">Maximum number of iterations.</param>
        /// <param name="failIfNotConverged">Fail if not converged after maxIterations.</param>
        /// <returns>Geometric median.</returns>
        [Sql.Function("ST_GeometricMedian", ServerSideOnly = true)]
        public static NTSG STGeometricMedian(this NTSG geometry, double tolerance, int maxIterations, bool failIfNotConverged)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns approximate geometric median of input MultiPoint geometry using the Weiszfeld algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometricMedian.html
        /// </remarks>
        /// <param name="geometry">Input geometry (MultiPoint).</param>
        /// <returns>Geometric median.</returns>
        [Sql.Function("ST_GeometricMedian", ServerSideOnly = true)]
        public static NTSG STGeometricMedian(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns smallest circle polygon that can fully contain input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MinimumBoundingCircle.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="segmentsPerQuarterCircle">Number of segments per quarter circle.</param>
        /// <returns>Circle polygon.</returns>
        [Sql.Function("ST_MinimumBoundingCircle", ServerSideOnly = true)]
        public static NTSG STMinimumBoundingCircle(this NTSG geometry, int segmentsPerQuarterCircle)
        {
            throw new InvalidOperationException();
        }

        // TODO: (geometry, double precision) ST_MinimumBoundingRadius(geometry geom) try map record to object[]

        /// <summary>
        /// Returns mimimum rotated rectangle enclosing input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_OrientedEnvelope.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Rotated rectangle.</returns>
        [Sql.Function("ST_OrientedEnvelope", ServerSideOnly = true)]
        public static NTSG STOrientedEnvelope(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? ST_Polygonize

        /// <summary>
        /// Returns offset line at given distance and side from input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_OffsetCurve.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="distance">Distance.</param>
        /// <param name="style">Style parameters.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_OffsetCurve", ServerSideOnly = true)]
        public static NTSG STOffsetCurve(this NTSG geometry, double distance, string style)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns POINT guaranteed to intersect a surface.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointOnSurface.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Point on surface.</returns>
        [Sql.Function("ST_PointOnSurface", ServerSideOnly = true)]
        public static NTSG STPointOnSurface(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a valid geometry with all coordinates rounded to provided grid tolerance.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ReducePrecision.html
        /// </remarks>
        /// <seealso cref="GeometryEditors.STSnapToGrid(NTSG, double)"/>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="size">Grid cell size.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ReducePrecision", ServerSideOnly = true)]
        public static NTSG STReducePrecision(this NTSG geometry, double size)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a collection containing paths shared by the two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SharedPaths.html
        /// </remarks>
        /// <param name="lineal1">Input geometry 1.</param>
        /// <param name="lineal2">Input geometry 2.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_SharedPaths", ServerSideOnly = true)]
        public static NTSG STSharedPaths(this NTSG lineal1, NTSG lineal2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns simplified version of input geometry using the Douglas-Peucker algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Simplify.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Tolerance value.</param>
        /// <param name="preserveCollapsed">Preserve collapsed.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Simplify", ServerSideOnly = true)]
        public static NTSG STSimplify(this NTSG geometry, double tolerance, bool preserveCollapsed)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns simplified version of input geometry using the Douglas-Peucker algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Simplify.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Tolerance value.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Simplify", ServerSideOnly = true)]
        public static NTSG STSimplify(this NTSG geometry, double tolerance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns simplified version of input geometry using the Douglas-Peucker algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SimplifyPreserveTopology.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Tolerance value.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_SimplifyPreserveTopology", ServerSideOnly = true)]
        public static NTSG STSimplifyPreserveTopology(this NTSG geometry, double tolerance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns simplified version of the given geometry using the Visvalingam-Whyatt algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SimplifyVW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Tolerance value.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_SimplifyVW", ServerSideOnly = true)]
        public static NTSG STSimplifyVW(this NTSG geometry, double tolerance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns smoothed version of input geometry using the Chaikin algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ChaikinSmoothing.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="iterations">Number of iterations.</param>
        /// <param name="preserveEndPoints">Preserve end points </param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ChaikinSmoothing", ServerSideOnly = true)]
        public static NTSG STChaikinSmoothing(this NTSG geometry, int iterations, bool preserveEndPoints)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns smoothed version of input geometry using the Chaikin algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ChaikinSmoothing.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ChaikinSmoothing", ServerSideOnly = true)]
        public static NTSG STChaikinSmoothing(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a geometry with only vertex points that have a m-value larger or equal to the min value and smaller or equal to the max value.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_FilterByM.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="min">Minimum value for M.</param>
        /// <param name="max">Maximum value for M.</param>
        /// <param name="returnM">Retun M value in resulting geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_FilterByM", ServerSideOnly = true)]
        public static NTSG STFilterByM(this NTSG geometry, double min, double max, bool returnM)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a geometry with only vertex points that have a m-value larger or equal to the min value and smaller or equal to the max value.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_FilterByM.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="min">Minimum value for M.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_FilterByM", ServerSideOnly = true)]
        public static NTSG STFilterByM(this NTSG geometry, double min)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Sets the effective area for each vertex, using the Visvalingam-Whyatt algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SetEffectiveArea.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="threshold">Threshold value.</param>
        /// <param name="setArea">Set area.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_SetEffectiveArea", ServerSideOnly = true)]
        public static NTSG STSetEffectiveArea(this NTSG geometry, double threshold, int setArea)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Sets the effective area for each vertex, using the Visvalingam-Whyatt algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SetEffectiveArea.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_SetEffectiveArea", ServerSideOnly = true)]
        public static NTSG STSetEffectiveArea(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Sets the effective area for each vertex, using the Visvalingam-Whyatt algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SetEffectiveArea.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="threshold">Threshold value.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_SetEffectiveArea", ServerSideOnly = true)]
        public static NTSG STSetEffectiveArea(this NTSG geometry, double threshold)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Computes a two-dimensional Voronoi diagram from the vertices of inpu geometry and returns the boundaries between cells in that diagram as a MultiLineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_VoronoiLines.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Threshold value.</param>
        /// <param name="extendTo">Extend to geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_VoronoiLines", ServerSideOnly = true)]
        public static NTSG STVoronoiLines(this NTSG geometry, double tolerance, NTSG extendTo)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Computes a two-dimensional Voronoi diagram from the vertices of inpu geometry and returns the boundaries between cells in that diagram as a MultiLineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_VoronoiLines.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">Threshold value.</param>
        /// <returns>Geometry (MultiLineString).</returns>
        [Sql.Function("ST_VoronoiLines", ServerSideOnly = true)]
        public static NTSG STVoronoiLines(this NTSG geometry, double tolerance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Computes a two-dimensional Voronoi diagram from the vertices of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_VoronoiPolygons.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">The distance within which vertices will be considered equivalent.</param>
        /// <param name="extendTo">Diagram will be extended to cover the envelope of the "extend_to" geometry.</param>
        /// <returns>Geometry (GeometryCollection of Polygons).</returns>
        [Sql.Function("ST_VoronoiPolygons", ServerSideOnly = true)]
        public static NTSG STVoronoiPolygons(this NTSG geometry, double tolerance, NTSG extendTo)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Computes a two-dimensional Voronoi diagram from the vertices of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_VoronoiPolygons.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry (GeometryCollection of Polygons).</returns>
        [Sql.Function("ST_VoronoiPolygons", ServerSideOnly = true)]
        public static NTSG STVoronoiPolygons(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Computes a two-dimensional Voronoi diagram from the vertices of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_VoronoiPolygons.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="tolerance">The distance within which vertices will be considered equivalent.</param>
        /// <returns>Geometry (GeometryCollection of Polygons).</returns>
        [Sql.Function("ST_VoronoiPolygons", ServerSideOnly = true)]
        public static NTSG STVoronoiPolygons(this NTSG geometry, double tolerance)
        {
            throw new InvalidOperationException();
        }
    }
}
