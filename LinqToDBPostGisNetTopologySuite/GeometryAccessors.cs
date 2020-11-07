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
        /// Returns true if the LINESTRING's start and end points are coincident. For Polyhedral Surfaces, reports if the surface is areal (open) or volumetric (closed).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsClosed.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Topological dimension</returns>
        [Sql.Function("ST_IsClosed", ServerSideOnly = true)]
        public static bool? STIsClosed(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if geometry is an empty geometry. If true, then this Geometry represents an empty geometry collection, polygon, point etc.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsEmpty.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Is empty</returns>
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
        /// Returns the number of points in a geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Number of points</returns>
        [Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int? STNPoints(this NTSG geometry)
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
        /// Returns the number of interior rings of a polygon geometry. Returns null if the geometry is not a polygon. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NumInteriorRings.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Number of interior rings</returns>
        [Sql.Function("ST_NumInteriorRings", ServerSideOnly = true)]
        public static int? STNumInteriorRings(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the number of points in given LineString or CircularString geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_NumPoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Number of points</returns>
        [Sql.Function("ST_NumPoints", ServerSideOnly = true)]
        public static int? STNumPoints(this NTSG geometry)
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
        /// Returns first point of a LINESTRING as a POINT. Returns null if the input is not a LINESTRING.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_StartPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>First point geometry</returns>
        [Sql.Function("ST_StartPoint", ServerSideOnly = true)]
        public static NTSG STStartPoint(this NTSG geometry)
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
    }
}