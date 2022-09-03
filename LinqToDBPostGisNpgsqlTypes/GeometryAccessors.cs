using System;

using LinqToDB;
using NpgsqlTypes;

namespace LinqToDBPostGisNpgsqlTypes
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Accessors
    public static class GeometryAccessors
    {
#pragma warning disable IDE0060
        /// <summary>
        /// Return the type of the geometry as a string.
        /// http://postgis.refractions.net/documentation/manual-1.5/GeometryType.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Type of the geometry as a string. Eg: 'LINESTRING', 'POLYGON', 'MULTIPOINT', etc.</returns>
        [Sql.Function("GeometryType", ServerSideOnly = true)]
        public static string GeometryType(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the coordinate dimension of the geometry value.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_CoordDim.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Coordinate dimension of the ST_Geometry value.</returns>
        [Sql.Function("ST_CoordDim", ServerSideOnly = true)]
        public static int STCoordDim(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// The inherent dimension of this Geometry object, which must be less than or equal to the coordinate dimension.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Dimension.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>The inherent dimension of this Geometry object, which must be less than or equal to the coordinate dimension. OGC SPEC s2.1.1.1 - returns 0 for POINT, 1 for LINESTRING, 2 for POLYGON, and the largest dimension of the components of a GEOMETRYCOLLECTION.</returns>
        [Sql.Function("ST_Dimension", ServerSideOnly = true)]
        public static int STDimension(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the last point of a LINESTRING geometry as a POINT.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_EndPoint.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Last point of a LINESTRING geometry as a POINT or NULL if the input parameter is not a LINESTRING.</returns>   
        [Sql.Function("ST_EndPoint", ServerSideOnly = true)]
        public static PostgisGeometry STEndPoint(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return geometry representing the double precision (float8) bounding box of the supplied geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Envelope.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Minimum bounding box for the supplied geometry</returns>
        [Sql.Function("ST_Envelope", ServerSideOnly = true)]
        public static PostgisGeometry STEnvelope(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the geometry type of the geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeometryType.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Type of the geometry as a string</returns>
        [Sql.Function("ST_GeometryType", ServerSideOnly = true)]
        public static string STGeometryType(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if this Geometry is an empty geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_IsEmpty.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>True if this Geometry is an empty geometry</returns>
        [Sql.Function("ST_IsEmpty", ServerSideOnly = true)]
        public static bool STIsEmpty(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if this LINESTRING is both closed and simple.
        /// </summary>
        /// <param name="geom">Input geometry (LINESTRING)</param>
        /// <returns>True if LINESTRING is both ST_IsClosed (ST_StartPoint(g) ~= ST_Endpoint(g)) and ST_IsSimple (does not self intersect)</returns>
        [Sql.Function("ST_IsRing", ServerSideOnly = true)]
        public static bool STIsRing(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if the geometry has no anomalous geometric points, such as self intersection or self tangency.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_IsSimple.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns></returns>
        [Sql.Function("ST_IsSimple", ServerSideOnly = true)]
        public static bool STIsSimple(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Returns true if the geometry is well formed.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_IsValid.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns></returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool STIsValid(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Returns coordinate dimension of the geometry as a small int. Values are: 2,3 or 4.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_NDims.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Coordinate dimension of the geometry</returns>
        [Sql.Function("ST_NDims", ServerSideOnly = true)]
        public static int STNDims(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the number of points (vertexes) in the geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_NPoints.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Number of points (vertexes)</returns>
        [Sql.Function("ST_NPoints", ServerSideOnly = true)]
        public static int STNPoints(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// If the geometry is a polygon or multi-polygon returns the number of rings.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_NRings.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Number of rings</returns>
        [Sql.Function("ST_NRings", ServerSideOnly = true)]
        public static int STNRings(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// If geometry is a GEOMETRYCOLLECTION (or MULTI*) return the number of geometries, otherwise return NULL.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_NumGeometries.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>The number of geometries.</returns>
        [Sql.Function("ST_NumGeometries", ServerSideOnly = true)]
        public static int STNumGeometries(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the Nth point in the first linestring or circular linestring in the geometry. Return NULL if there is no linestring in the geometry.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_PointN.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>The Nth point in the first linestring or circular linestring in the geometry.</returns>
        [Sql.Function("ST_PointN", ServerSideOnly = true)]
        public static PostgisGeometry STPointN(this PostgisGeometry geom, int n) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the spatial reference identifier for the ST_Geometry as defined in spatial_ref_sys table.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_SRID.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Spatial reference identifier</returns>
        [Sql.Function("ST_SRID", ServerSideOnly = true)]
        public static int STSrId(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the first  point of a LINESTRING geometry as a POINT.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_EndPoint.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>First point of a LINESTRING geometry as a POINT or NULL if the input parameter is not a LINESTRING.</returns>   
        [Sql.Function("ST_StartPoint", ServerSideOnly = true)]
        public static PostgisGeometry STStartPoint(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the X coordinate of the point, or NULL if not available. Input must be a point.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_X.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>X coordinate</returns>
        [Sql.Function("ST_X", ServerSideOnly = true)]
        public static double STX(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the Y coordinate of the point, or NULL if not available. Input must be a point.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Y.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Y coordinate</returns>
        [Sql.Function("ST_Y", ServerSideOnly = true)]
        public static double STY(this PostgisGeometry geom) => throw new InvalidOperationException();
#pragma warning restore IDE0060
    }
}
