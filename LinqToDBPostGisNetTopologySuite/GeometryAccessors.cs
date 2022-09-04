using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Accessors.
    /// </summary>
    /// <remarks>
    /// 5.4. Geometry Accessors
    /// https://postgis.net/docs/reference.html#Geometry_Accessors
    /// </remarks>
    public static class GeometryAccessors
    {
#pragma warning disable IDE0060
        /// <summary>
        /// Returns the type of input <paramref name="geometry"/> as string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/GeometryType.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry type string (Eg: 'LINESTRING', 'POLYGON', 'MULTIPOINT', etc.).</returns>
        [Sql.Function("GeometryType", ServerSideOnly = true)]
        public static string GeometryType(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the closure of the combinatorial boundary of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Boundary.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Boundary geometry.</returns>
        [Sql.Function("ST_Boundary", ServerSideOnly = true)]
        public static NTSG STBoundary(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the closure of the combinatorial boundary of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Boundary.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Boundary geometry.</returns>
        [Sql.Function("ST_Boundary", ServerSideOnly = true)]
        public static NTSG STBoundary(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the coordinate dimension of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CoordDim.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Coordinate dimension.</returns>
        [Sql.Function("ST_CoordDim", ServerSideOnly = true)]
        public static int? STCoordDim(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the coordinate dimension of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CoordDim.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Coordinate dimension.</returns>
        [Sql.Function("ST_CoordDim", ServerSideOnly = true)]
        public static int? STCoordDim(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the topological dimension of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Dimension.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Topological dimension (must be less than or equal to the coordinate dimension).</returns>
        [Sql.Function("ST_Dimension", ServerSideOnly = true)]
        public static int? STDimension(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the topological dimension of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Dimension.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Topological dimension (must be less than or equal to the coordinate dimension).</returns>
        [Sql.Function("ST_Dimension", ServerSideOnly = true)]
        public static int? STDimension(string geometry) => throw new InvalidOperationException();

        // TODO: ? geometry_dump[] ST_Dump(geometry g1);
        // TODO: ? geometry_dump[] ST_DumpPoints(geometry geom);
        // TODO: ? geometry_dump[] ST_DumpRings(geometry a_polygon);

        /// <summary>
        /// Returns the last point of input <paramref name="geometry"/> as a Point. Returns null if the input is not a LineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_EndPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <returns>Last point.</returns>
        [Sql.Function("ST_EndPoint", ServerSideOnly = true)]
        public static NTSG STEndPoint(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the last point of input <paramref name="geometry"/> in text representation as a Point. Returns null if the input is not a LineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_EndPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <returns>Last point.</returns>
        [Sql.Function("ST_EndPoint", ServerSideOnly = true)]
        public static NTSG STEndPoint(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the minimum bounding box for input <paramref name="geometry"/>, as geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Envelope.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Bounding box geometry.</returns>
        [Sql.Function("ST_Envelope", ServerSideOnly = true)]
        public static NTSG STEnvelope(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the minimum bounding box for input <paramref name="geometry"/> in text representation, as geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Envelope.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Bounding box geometry.</returns>
        [Sql.Function("ST_Envelope", ServerSideOnly = true)]
        public static NTSG STEnvelope(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the diagonal of input <paramref name="geometry"/> bounding box.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_BoundingDiagonal.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Diagonal of the bounding box (LineString).</returns>
        [Sql.Function("ST_BoundingDiagonal", ServerSideOnly = true)]
        public static NTSG STBoundingDiagonal(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the diagonal of input <paramref name="geometry"/> in text representation bounding box.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_BoundingDiagonal.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Diagonal of the bounding box (LineString).</returns>
        [Sql.Function("ST_BoundingDiagonal", ServerSideOnly = true)]
        public static NTSG STBoundingDiagonal(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the diagonal of input <paramref name="geometry"/> bounding box.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_BoundingDiagonal.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="fits">Specifies if the best fit is needed.</param>
        /// <returns>Diagonal of the bounding box (LineString).</returns>
        [Sql.Function("ST_BoundingDiagonal", ServerSideOnly = true)]
        public static NTSG STBoundingDiagonal(this NTSG geometry, bool fits) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the diagonal of input <paramref name="geometry"/> in text representation bounding box.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_BoundingDiagonal.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="fits">Specifies if the best fit is needed.</param>
        /// <returns>Diagonal of the bounding box (LineString).</returns>
        [Sql.Function("ST_BoundingDiagonal", ServerSideOnly = true)]
        public static NTSG STBoundingDiagonal(string geometry, bool fits) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the exterior ring of input <paramref name="geometry"/>. Returns null if input <paramref name="geometry"/> is not a Polygon.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ExteriorRing.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <returns>Exterior ring geometry (LineString).</returns>
        [Sql.Function("ST_ExteriorRing", ServerSideOnly = true)]
        public static NTSG STExteriorRing(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the exterior ring of input <paramref name="geometry"/> in text representation. Returns null if input <paramref name="geometry"/> is not a Polygon.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ExteriorRing.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <returns>Exterior ring geometry (LineString).</returns>
        [Sql.Function("ST_ExteriorRing", ServerSideOnly = true)]
        public static NTSG STExteriorRing(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth geometry of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometryN.html
        /// </remarks>
        /// <param name="geometry">Input geometry (GeometryCollection, Multi* or PolyhedralSurface).</param>
        /// <param name="n">Index of geometry (1-based).</param>
        /// <returns>Nth geometry.</returns>
        [Sql.Function("ST_GeometryN", ServerSideOnly = true)]
        public static NTSG STGeometryN(this NTSG geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth geometry of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometryN.html
        /// </remarks>
        /// <param name="geometry">Input geometry (GeometryCollection, Multi* or PolyhedralSurface).</param>
        /// <param name="n">Index of geometry (1-based).</param>
        /// <returns>Nth geometry.</returns>
        [Sql.Function("ST_GeometryN", ServerSideOnly = true)]
        public static NTSG STGeometryN(string geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the type of input <paramref name="geometry"/> as string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometryType.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry type string (with 'ST_' prefix).</returns>
        [Sql.Function("ST_GeometryType", ServerSideOnly = true)]
        public static string STGeometryType(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the type of input <paramref name="geometry"/> in text representation as string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometryType.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry type string (with 'ST_' prefix).</returns>
        [Sql.Expression("ST_GeometryType({0}::geometry)", ServerSideOnly = true)]
        public static string STGeometryType(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> contains a circular string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_HasArc.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Input geometry or geometry collection contains a circular string.</returns>
        [Sql.Function("ST_HasArc", ServerSideOnly = true)]
        public static bool? STHasArc(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> in text representation contains a circular string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_HasArc.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Input geometry or geometry collection contains a circular string.</returns>
        [Sql.Function("ST_HasArc", ServerSideOnly = true)]
        public static bool? STHasArc(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth interior ring of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_InteriorRingN.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <param name="n">Index of interior ring (1-based).</param>
        /// <returns>Nth ring.</returns>
        [Sql.Function("ST_InteriorRingN", ServerSideOnly = true)]
        public static NTSG STInteriorRingN(this NTSG geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth interior ring of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_InteriorRingN.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <param name="n">Index of interior ring (1-based).</param>
        /// <returns>Nth ring.</returns>
        [Sql.Function("ST_InteriorRingN", ServerSideOnly = true)]
        public static NTSG STInteriorRingN(string geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if all polygonal components of input <paramref name="geometry"/> use a counter-clockwise orientation for their exterior ring, and a clockwise direction for all interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsPolygonCCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsPolygonCCW", ServerSideOnly = true)]
        public static bool? STIsPolygonCCW(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if all polygonal components of input <paramref name="geometry"/> in text representation use a counter-clockwise orientation for their exterior ring, and a clockwise direction for all interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsPolygonCCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsPolygonCCW", ServerSideOnly = true)]
        public static bool? STIsPolygonCCW(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if all polygonal components of input <paramref name="geometry"/> use a clockwise orientation for their exterior ring, and a counter-clockwise direction for all interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsPolygonCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsPolygonCW", ServerSideOnly = true)]
        public static bool? STIsPolygonCW(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if all polygonal components of input <paramref name="geometry"/> in text representation use a clockwise orientation for their exterior ring, and a counter-clockwise direction for all interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsPolygonCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsPolygonCW", ServerSideOnly = true)]
        public static bool? STIsPolygonCW(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input LineString <paramref name="geometry"/> start and end points are coincident.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsClosed.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsClosed", ServerSideOnly = true)]
        public static bool? STIsClosed(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input LineString <paramref name="geometry"/> in text representation start and end points are coincident.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsClosed.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsClosed", ServerSideOnly = true)]
        public static bool? STIsClosed(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> type is a geometry collection type.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsCollection.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsCollection", ServerSideOnly = true)]
        public static bool? STIsCollection(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> in text representation type is a geometry collection type.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsCollection.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsCollection", ServerSideOnly = true)]
        public static bool? STIsCollection(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> is an empty geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsEmpty.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry is empty.</returns>
        [Sql.Function("ST_IsEmpty", ServerSideOnly = true)]
        public static bool? STIsEmpty(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> in text representation is an empty geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsEmpty.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry is empty.</returns>
        [Sql.Function("ST_IsEmpty", ServerSideOnly = true)]
        public static bool? STIsEmpty(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> is both IsClosed and IsSimple (does not self intersect).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsRing.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry is ring.</returns>
        [Sql.Function("ST_IsRing", ServerSideOnly = true)]
        public static bool? STIsRing(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> in text representation is both IsClosed and IsSimple (does not self intersect).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsRing.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry is ring.</returns>
        [Sql.Function("ST_IsRing", ServerSideOnly = true)]
        public static bool? STIsRing(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> has no anomalous geometric points, such as self intersection or self tangency.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsSimple.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry is simple.</returns>
        [Sql.Function("ST_IsSimple", ServerSideOnly = true)]
        public static bool? STIsSimple(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if input <paramref name="geometry"/> in text representation has no anomalous geometric points, such as self intersection or self tangency.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsSimple.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry is simple.</returns>
        [Sql.Function("ST_IsSimple", ServerSideOnly = true)]
        public static bool? STIsSimple(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns M coordinate (measure) of input Point <paramref name="geometry"/>, or null if not available.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_M.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of M coordinate (measure).</returns>
        [Sql.Function("ST_M", ServerSideOnly = true)]
        public static double? STM(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns M coordinate (measure) of input Point <paramref name="geometry"/> in text representation, or null if not available.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_M.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of M coordinate (measure).</returns>
        [Sql.Function("ST_M", ServerSideOnly = true)]
        public static double? STM(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the amount of memory space (in bytes) input <paramref name="geometry"/> takes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MemSize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Amount of memory space (in bytes).</returns>
        [Sql.Function("ST_MemSize", ServerSideOnly = true)]
        public static int? STMemSize(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the amount of memory space (in bytes) input <paramref name="geometry"/> in text representation takes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MemSize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Amount of memory space (in bytes).</returns>
        [Sql.Function("ST_MemSize", ServerSideOnly = true)]
        public static int? STMemSize(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the coordinate dimension of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NDims.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Coordinate dimension.</returns>
        [Sql.Function("ST_NDims", ServerSideOnly = true)]
        public static int? STNDims(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the coordinate dimension of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NDims.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Coordinate dimension.</returns>
        [Sql.Function("ST_NDims", ServerSideOnly = true)]
        public static int? STNDims(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of points in input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of points.</returns>
        [Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int? STNPoints(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of points in input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of points.</returns>
        [Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int? STNPoints(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of rings in input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon or MultiPolygon).</param>
        /// <returns>Number of rings.</returns>
        [Sql.Function("ST_NRings", ServerSideOnly = true)]
        public static int? STNRings(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of rings in input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon or MultiPolygon).</param>
        /// <returns>Number of rings.</returns>
        [Sql.Function("ST_NRings", ServerSideOnly = true)]
        public static int? STNRings(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of geometries in input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumGeometries.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of geometries.</returns>
        [Sql.Function("ST_NumGeometries", ServerSideOnly = true)]
        public static int? STNumGeometries(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of geometries in input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumGeometries.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of geometries.</returns>
        [Sql.Function("ST_NumGeometries", ServerSideOnly = true)]
        public static int? STNumGeometries(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of interior rings in input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumInteriorRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <returns>Number of interior rings.</returns>
        [Sql.Function("ST_NumInteriorRings", ServerSideOnly = true)]
        public static int? STNumInteriorRings(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of interior rings in input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumInteriorRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <returns>Number of interior rings.</returns>
        [Sql.Function("ST_NumInteriorRings", ServerSideOnly = true)]
        public static int? STNumInteriorRings(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of interior rings in input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumInteriorRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <returns>Number of interior rings.</returns>
        [Sql.Function("ST_NumInteriorRing", ServerSideOnly = true)]
        public static int? STNumInteriorRing(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of interior rings in input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumInteriorRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <returns>Number of interior rings.</returns>
        [Sql.Function("ST_NumInteriorRing", ServerSideOnly = true)]
        public static int? STNumInteriorRing(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of faces on input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumPatches.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polyhedral Surface).</param>
        /// <returns>Number of faces, null for non-polyhedral geometries.</returns>
        [Sql.Function("ST_NumPatches", ServerSideOnly = true)]
        public static int? STNumPatches(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of faces on input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumPatches.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polyhedral Surface).</param>
        /// <returns>Number of faces, null for non-polyhedral geometries.</returns>
        [Sql.Function("ST_NumPatches", ServerSideOnly = true)]
        public static int? STNumPatches(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of points in input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString or CircularString).</param>
        /// <returns>Number of points.</returns>
        [Sql.Function("ST_NumPoints", ServerSideOnly = true)]
        public static int? STNumPoints(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the number of points in input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_NumPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString or CircularString).</param>
        /// <returns>Number of points.</returns>
        [Sql.Function("ST_NumPoints", ServerSideOnly = true)]
        public static int? STNumPoints(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth face of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PatchN.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="n">Index of face (1-based).</param>
        /// <returns>Nth face.</returns>
        [Sql.Function("ST_PatchN", ServerSideOnly = true)]
        public static NTSG STPatchN(this NTSG geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth face of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PatchN.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="n">Index of face (1-based).</param>
        /// <returns>Nth face.</returns>
        [Sql.Function("ST_PatchN", ServerSideOnly = true)]
        public static NTSG STPatchN(string geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth point in input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointN.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString or CircularString).</param>
        /// <param name="n">Index of point (1-based).</param>
        /// <returns>Nth point.</returns>
        [Sql.Function("ST_PointN", ServerSideOnly = true)]
        public static NTSG STPointN(this NTSG geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the Nth point in input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointN.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString or CircularString).</param>
        /// <param name="n">Index of point (1-based).</param>
        /// <returns>Nth point.</returns>
        [Sql.Function("ST_PointN", ServerSideOnly = true)]
        public static NTSG STPointN(string geometry, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns geometry (MultiPoint), containing all of the coordinates of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Points.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>MultiPoint geometry.</returns>
        [Sql.Function("ST_Points", ServerSideOnly = true)]
        public static NTSG STPoints(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns geometry (MultiPoint), containing all of the coordinates of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Points.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>MultiPoint geometry.</returns>
        [Sql.Function("ST_Points", ServerSideOnly = true)]
        public static NTSG STPoints(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns first point of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_StartPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>First point geometry (Point).</returns>
        [Sql.Function("ST_StartPoint", ServerSideOnly = true)]
        public static NTSG STStartPoint(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns first point of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_StartPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>First point geometry (Point).</returns>
        [Sql.Function("ST_StartPoint", ServerSideOnly = true)]
        public static NTSG STStartPoint(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a text summary of the contents of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Summary.html
        /// </remarks>
        /// <param name="geometry">Input geometry (or geography).</param>
        /// <returns>Text summary.</returns>
        [Sql.Function("ST_Summary", ServerSideOnly = true)]
        public static string STSummary(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns X coordinate of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_X.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of X coordinate.</returns>
        [Sql.Function("ST_X", ServerSideOnly = true)]
        public static double? STX(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns X coordinate of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_X.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of X coordinate.</returns>
        [Sql.Function("ST_X", ServerSideOnly = true)]
        public static double? STX(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns Y coordinate of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Y.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of Y coordinate.</returns>
        [Sql.Function("ST_Y", ServerSideOnly = true)]
        public static double? STY(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns Y coordinate of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Y.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of Y coordinate.</returns>
        [Sql.Function("ST_Y", ServerSideOnly = true)]
        public static double? STY(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns Z coordinate of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Z.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of Z coordinate.</returns>
        [Sql.Function("ST_Z", ServerSideOnly = true)]
        public static double? STZ(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns Z coordinate of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Z.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>Value of Z coordinate.</returns>
        [Sql.Function("ST_Z", ServerSideOnly = true)]
        public static double? STZ(string geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a code indicating the ZM coordinate dimension of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Zmflag.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>ZM coordinate dimension code.</returns>
        [Sql.Function("ST_Zmflag", ServerSideOnly = true)]
        public static int? STZmflag(this NTSG geometry) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a code indicating the ZM coordinate dimension of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Zmflag.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>ZM coordinate dimension code.</returns>
        [Sql.Function("ST_Zmflag", ServerSideOnly = true)]
        public static int? STZmflag(string geometry) => throw new InvalidOperationException();
#pragma warning restore IDE0060
    }
}
