using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Processing
    /// </summary>
    /// <remarks>
    /// 5.14. Geometry Processing https://postgis.net/docs/reference.html#Geometry_Processing
    /// </remarks>
    public static class GeometryProcessing
    {
        /// <summary>
        /// Returns geometry that represents all points whose distance from input geometry is less than or equal to distance. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Buffer.html
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
        /// See https://postgis.net/docs/ST_Buffer.html
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
        /// See https://postgis.net/docs/ST_Buffer.html
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
        /// See https://postgis.net/docs/ST_BuildArea.html
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
        /// See https://postgis.net/docs/ST_Centroid.html
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
        /// See https://postgis.net/docs/ST_ClipByBox2D.html
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
        /// See https://postgis.net/docs/ST_ConcaveHull.html
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
        /// See https://postgis.net/docs/ST_ConcaveHull.html
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
        /// See https://postgis.net/docs/ST_ConvexHull.html
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
        /// See https://postgis.net/docs/ST_CurveToLine.html
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
        /// See https://postgis.net/docs/ST_DelaunayTriangles.html
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
        /// See https://postgis.net/docs/ST_Difference.html
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
        /// See https://postgis.net/docs/ST_FlipCoordinates.html
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
        /// See https://postgis.net/docs/ST_GeneratePoints.html
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
        /// See https://postgis.net/docs/ST_GeneratePoints.html
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
        /// Returns approximate geometric median of input MultiPoint geometry using the Weiszfeld algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometricMedian.html
        /// </remarks>
        /// <param name="geometry">Input geometry (MultiPoint)</param>
        /// <param name="tolerance">Tolerance value</param>
        /// <param name="maxIterations">Maximum number of iterations</param>
        /// <param name="failIfNotConverged">Fail if not converged after maxIterations</param>
        /// <returns>Geometric median</returns>
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
        /// <param name="geometry">Input geometry (MultiPoint)</param>
        /// <returns>Geometric median</returns>
        [Sql.Function("ST_GeometricMedian", ServerSideOnly = true)]
        public static NTSG STGeometricMedian(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents the point set intersection of given geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Intersection.html
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
        /// Converts plain input LineString/Polygon to CircularString/CurvePolygon.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineToCurve.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString/Polygon)</param>
        /// <returns>Curved equivalent of input geometry</returns>
        [Sql.Function("ST_LineToCurve", ServerSideOnly = true)]
        public static NTSG STLineToCurve(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_MemUnion(geometry set)

        /// <summary>
        /// Returns smallest circle polygon that can fully contain input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MinimumBoundingCircle.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="segmentsPerQuarterCircle">Number of segments per quarter circle</param>
        /// <returns>Circle polygon</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <returns>Rotated rectangle</returns>
        [Sql.Function("ST_OrientedEnvelope", ServerSideOnly = true)]
        public static NTSG STOrientedEnvelope(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? ST_Polygonize

        /// <summary>
        /// Fully node set of linestrings using the least possible number of nodes while preserving all of the input ones.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Node.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Node", ServerSideOnly = true)]
        public static NTSG STNode(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns offset line at given distance and side from input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_OffsetCurve.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString)</param>
        /// <param name="distance">Distance</param>
        /// <param name="style">Style parameters</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <returns>Point on surface</returns>
        [Sql.Function("ST_PointOnSurface", ServerSideOnly = true)]
        public static NTSG STPointOnSurface(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns input geometry with duplicated points removed.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RemoveRepeatedPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Tolerance</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_RemoveRepeatedPoints", ServerSideOnly = true)]
        public static NTSG STRemoveRepeatedPoints(this NTSG geometry, double tolerance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a collection containing paths shared by the two input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SharedPaths.html
        /// </remarks>
        /// <param name="lineal1">Input geometry 1</param>
        /// <param name="lineal2">Input geometry 2</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_SharedPaths", ServerSideOnly = true)]
        public static NTSG STSharedPaths(this NTSG lineal1, NTSG lineal2)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Reads every point/vertex in every component of every feature in input geometry, and if the longitude coordinate is less than 0, adds 360 to it.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Shift_Longitude.html
        /// </remarks>
        /// <param name="geometry">Input geometry (in long lat only)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_ShiftLongitude", ServerSideOnly = true)]
        public static NTSG STShiftLongitude(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Splits the input geometries and then moves every resulting component falling on the right (for negative 'move') or on the left (for positive 'move') of given 'wrap' line in the direction specified by the 'move' parameter, finally re-unioning the pieces togheter.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_WrapX.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="wrap">Wrap line coordinate</param>
        /// <param name="move">Move offset</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_WrapX", ServerSideOnly = true)]
        public static NTSG STWrapX(this NTSG geometry, double wrap, double move)
        {
            throw new InvalidOperationException(); // TODO: tests
        }

        /// <summary>
        /// Returns simplified version of input geometry using the Douglas-Peucker algorithm.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Simplify.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Tolerance value</param>
        /// <param name="preserveCollapsed">Preserve collapsed</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Tolerance value</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Tolerance value</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Tolerance value</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="iterations">Number of iterations</param>
        /// <param name="preserveEndPoints">Preserve end points </param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="min">Minimum value for M</param>
        /// <param name="max">Maximum value for M</param>
        /// <param name="returnM">Retun M value in resulting geometry</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="min">Minimum value for M</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="threshold">Threshold value</param>
        /// <param name="setArea">Set area</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="threshold">Threshold value</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_SetEffectiveArea", ServerSideOnly = true)]
        public static NTSG STSetEffectiveArea(this NTSG geometry, double threshold)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Splitting input line by (multi)point, (multi)line or (multi)polygon boundary, a (multi)polygon by line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Split.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="blade">Boundary geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Split", ServerSideOnly = true)]
        public static NTSG STSplit(this NTSG geometry, NTSG blade)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry that represents the portions of A and B that do not intersect.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SymDifference.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Difference geometry</returns>
        [Sql.Function("ST_SymDifference", ServerSideOnly = true)]
        public static NTSG STSymDifference(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        // TODO: setof geometry ST_Subdivide

        /// <summary>
        /// Returns union of input geometries.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Union.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Union geometry</returns>
        [Sql.Function("ST_Union", ServerSideOnly = true)]
        public static NTSG STUnion(this NTSG geometry, NTSG other) // TODO: geometry set / geometry[]
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns union of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_UnaryUnion.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Union geometry</returns>
        [Sql.Function("ST_UnaryUnion", ServerSideOnly = true)]
        public static NTSG STUnaryUnion(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Computes a two-dimensional Voronoi diagram from the vertices of inpu geometry and returns the boundaries between cells in that diagram as a MultiLineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_VoronoiLines.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Threshold value</param>
        /// <param name="extendTo">Extend to geometry</param>
        /// <returns>Geometry</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">Threshold value</param>
        /// <returns>Geometry (MultiLineString)</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">The distance within which vertices will be considered equivalent</param>
        /// <param name="extendTo">Diagram will be extended to cover the envelope of the "extend_to" geometry</param>
        /// <returns>Geometry (GeometryCollection of Polygons)</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry (GeometryCollection of Polygons)</returns>
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
        /// <param name="geometry">Input geometry</param>
        /// <param name="tolerance">The distance within which vertices will be considered equivalent</param>
        /// <returns>Geometry (GeometryCollection of Polygons)</returns>
        [Sql.Function("ST_VoronoiPolygons", ServerSideOnly = true)]
        public static NTSG STVoronoiPolygons(this NTSG geometry, double tolerance)
        {
            throw new InvalidOperationException();
        }
    }
}
