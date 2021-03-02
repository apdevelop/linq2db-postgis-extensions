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
        /// Returns the type of geometry as string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/GeometryType.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry type string</returns>
        [Sql.Function("GeometryType", ServerSideOnly = true)]
        public static string GeometryType(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the closure of the combinatorial boundary of given geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Boundary.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Boundary geometry</returns>
        [Sql.Function("ST_Boundary", ServerSideOnly = true)]
        public static NTSG STBoundary(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the coordinate dimension of given geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_CoordDim.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Coordinate  dimension</returns>
        [Sql.Function("ST_CoordDim", ServerSideOnly = true)]
        public static int? STCoordDim(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the topological dimension of geometry, which must be less than or equal to the coordinate dimension.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Dimension.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Topological dimension</returns>
        [Sql.Function("ST_Dimension", ServerSideOnly = true)]
        public static int? STDimension(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? geometry_dump[] ST_Dump(geometry g1);
        // TODO: ? geometry_dump[] ST_DumpPoints(geometry geom);
        // TODO: ? geometry_dump[] ST_DumpRings(geometry a_polygon);

        /// <summary>
        /// Returns last point of a LINESTRING as a POINT. Returns null if the input is not a LINESTRING.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_EndPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Last point geometry</returns>
        [Sql.Function("ST_EndPoint", ServerSideOnly = true)]
        public static NTSG STEndPoint(this NTSG geometry)
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

        /// <summary>
        /// Returns the diagonal of the <paramref name="geometry"/> bounding box as a LineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_BoundingDiagonal.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Diagonal of the bounding box.</returns>
        [Sql.Function("ST_BoundingDiagonal", ServerSideOnly = true)]
        public static NTSG STBoundingDiagonal(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the diagonal of the <paramref name="geometry"/> bounding box as a LineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_BoundingDiagonal.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="fits">Specifies if the best fit is needed.</param>
        /// <returns>Diagonal of the bounding box.</returns>
        [Sql.Function("ST_BoundingDiagonal", ServerSideOnly = true)]
        public static NTSG STBoundingDiagonal(this NTSG geometry, bool fits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns LINESTRING representing the exterior ring of the POLYGON geometry. Returns null the geometry is not a polygon.
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
        /// Returns the Nth geometry if given geometry is a GEOMETRYCOLLECTION, (MULTI)POINT, (MULTI)LINESTRING, MULTICURVE or (MULTI)POLYGON, POLYHEDRALSURFACE Otherwise, return null.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeometryN.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="n">Index of geometry (1-based)</param>
        /// <returns>Nth geometry</returns>
        [Sql.Function("ST_GeometryN", ServerSideOnly = true)]
        public static NTSG STGeometryN(this NTSG geometry, int n)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the type of geometry as string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeometryType.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry type string (with ST_ prefix)</returns>
        [Sql.Function("ST_GeometryType", ServerSideOnly = true)]
        public static string STGeometryType(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if a geometry or geometry collection contains a circular string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_HasArc.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry or geometry collection contains a circular string.</returns>
        [Sql.Function("ST_HasArc", ServerSideOnly = true)]
        public static bool? STHasArc(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Nth interior ring of the input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_InteriorRingN.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Polygon).</param>
        /// <param name="n">Index of interior ring (1-based).</param>
        /// <returns>Nth ring</returns>
        [Sql.Function("ST_InteriorRingN", ServerSideOnly = true)]
        public static NTSG STInteriorRingN(this NTSG geometry, int n)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if all polygonal components of the input <paramref name="geometry"/> use a counter-clockwise orientation for their exterior ring, and a clockwise direction for all interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsPolygonCCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsPolygonCCW", ServerSideOnly = true)]
        public static bool? STIsPolygonCCW(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if all polygonal components of the input <paramref name="geometry"/> use a clockwise orientation for their exterior ring, and a counter-clockwise direction for all interior rings.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsPolygonCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsPolygonCW", ServerSideOnly = true)]
        public static bool? STIsPolygonCW(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the LINESTRING's start and end points are coincident. For Polyhedral Surfaces, reports if the surface is areal (open) or volumetric (closed).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsClosed.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsClosed", ServerSideOnly = true)]
        public static bool? STIsClosed(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the <paramref name="geometry"/> type is a geometry collection type.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsCollection.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Check result.</returns>
        [Sql.Function("ST_IsCollection", ServerSideOnly = true)]
        public static bool? STIsCollection(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if the <paramref name="geometry"/> is an empty geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsEmpty.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Is empty.</returns>
        [Sql.Function("ST_IsEmpty", ServerSideOnly = true)]
        public static bool? STIsEmpty(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if given LINESTRING is both IsClosed and IsSimple (does not self intersect).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsRing.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Is ring</returns>
        [Sql.Function("ST_IsRing", ServerSideOnly = true)]
        public static bool? STIsRing(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if given geometry has no anomalous geometric points, such as self intersection or self tangency. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsSimple.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Is simple</returns>
        [Sql.Function("ST_IsSimple", ServerSideOnly = true)]
        public static bool? STIsSimple(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns M coordinate (measure) of Point, or null if not available. Input must be a Point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_M.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>M coordinate</returns>
        [Sql.Function("ST_M", ServerSideOnly = true)]
        public static double? STM(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the amount of memory (in bytes) the <paramref name="geometry"/> takes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MemSize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Amount of memory space (in bytes)</returns>
        [Sql.Function("ST_MemSize", ServerSideOnly = true)]
        public static int? STMemSize(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the coordinate dimension of the <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NDims.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Coordinate dimension.</returns>
        [Sql.Function("ST_NDims", ServerSideOnly = true)]
        public static int? STNDims(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of points in the <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of points.</returns>
        [Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int? STNPoints(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of rings of the <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of rings.</returns>
        [Sql.Function("ST_NRings", ServerSideOnly = true)]
        public static int? STNRings(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of geometries in a GEOMETRYCOLLECTION (or MULTI*), or 1, for single geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NumGeometries.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Number of geometries</returns>
        [Sql.Function("ST_NumGeometries", ServerSideOnly = true)]
        public static int? STNumGeometries(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of interior rings of the <paramref name="geometry"/>. Returns null if the geometry is not a polygon. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NumInteriorRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of interior rings.</returns>
        [Sql.Function("ST_NumInteriorRings", ServerSideOnly = true)]
        public static int? STNumInteriorRings(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of interior rings of the <paramref name="geometry"/>. Returns null if the geometry is not a polygon. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NumInteriorRing.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of interior rings.</returns>
        [Sql.Function("ST_NumInteriorRing", ServerSideOnly = true)]
        public static int? STNumInteriorRing(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of faces on a Polyhedral Surface.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NumPatches.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of faces, null for non-polyhedral geometries.</returns>
        [Sql.Function("ST_NumPatches", ServerSideOnly = true)]
        public static int? STNumPatches(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of points in given LineString or CircularString geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NumPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Number of points.</returns>
        [Sql.Function("ST_NumPoints", ServerSideOnly = true)]
        public static int? STNumPoints(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Nth geometry (face) if the geometry is a POLYHEDRALSURFACE or POLYHEDRALSURFACEM.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PatchN.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="n">Index of geometry (1-based)</param>
        /// <returns>Nth face</returns>
        [Sql.Function("ST_PatchN", ServerSideOnly = true)]
        public static NTSG STPatchN(this NTSG geometry, int n)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Nth point in a single linestring or circular linestring in the geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointN.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="n">Index of point (1-based)</param>
        /// <returns>Nth point</returns>
        [Sql.Function("ST_PointN", ServerSideOnly = true)]
        public static NTSG STPointN(this NTSG geometry, int n)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a MultiPoint containing all of the coordinates of a <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Points.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>MultiPoint geometry.</returns>
        [Sql.Function("ST_Points", ServerSideOnly = true)]
        public static NTSG STPoints(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns first point of a LINESTRING as a Point. Returns null if the input is not a LINESTRING.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_StartPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>First point geometry.</returns>
        [Sql.Function("ST_StartPoint", ServerSideOnly = true)]
        public static NTSG STStartPoint(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a text summary of the contents of the <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Summary.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Text summary.</returns>
        [Sql.Function("ST_Summary", ServerSideOnly = true)]
        public static string STSummary(this NTSG geometry) // TODO: geography 
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns X coordinate of Point, or null if not available. Input must be a Point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_X.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>X coordinate</returns>
        [Sql.Function("ST_X", ServerSideOnly = true)]
        public static double? STX(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Y coordinate of Point, or null if not available. Input must be a Point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Y.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Y coordinate</returns>
        [Sql.Function("ST_Y", ServerSideOnly = true)]
        public static double? STY(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Z coordinate of Point, or null if not available. Input must be a Point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Z.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Z coordinate</returns>
        [Sql.Function("ST_Z", ServerSideOnly = true)]
        public static double? STZ(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a code indicating the ZM coordinate dimension of a <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Zmflag.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>ZM coordinate dimension code.</returns>
        [Sql.Function("ST_Zmflag", ServerSideOnly = true)]
        public static int? STZmflag(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}
