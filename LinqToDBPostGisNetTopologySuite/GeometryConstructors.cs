using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Constructors
    /// </summary>
    /// <remarks>
    /// 8.3. Geometry Constructors https://postgis.net/docs/manual-3.0/reference.html#Geometry_Constructors
    /// </remarks>
    public static class GeometryConstructors
    {
        /// <summary>
        /// Collects geometries into a geometry collection. The result is either a Multi* or a GeometryCollection, depending on whether the input geometries have the same or different types (homogeneous or heterogeneous).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Collect.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Collected geometry</returns>
        [Sql.Function("ST_Collect", ServerSideOnly = true)]
        public static NTSG STCollect(this NTSG geometry, NTSG other) // TODO: other versions
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates LineString from MultiPoint geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineFromMultiPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (MultiPoint)</param>
        /// <returns>Constructed geometry</returns>
        [Sql.Function("ST_LineFromMultiPoint", ServerSideOnly = true)]
        public static NTSG STLineFromMultiPoint(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a rectangular Polygon from the minimum and maximum values for X and Y.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakeEnvelope.html
        /// </remarks>
        /// <param name="xmin">Minimum X coordinate</param>
        /// <param name="ymin">Minimum Y coordinate</param>
        /// <param name="xmax">Maximum X coordinate</param>
        /// <param name="ymax">Maximum Y coordinate</param>
        /// <returns>Constructed geometry</returns>
        [Sql.Function("ST_MakeEnvelope", ServerSideOnly = true)]
        public static NTSG STMakeEnvelope(double xmin, double ymin, double xmax, double ymax)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a rectangular Polygon from the minimum and maximum values for X and Y.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakeEnvelope.html
        /// </remarks>
        /// <param name="xmin">Minimum X coordinate</param>
        /// <param name="ymin">Minimum Y coordinate</param>
        /// <param name="xmax">Maximum X coordinate</param>
        /// <param name="ymax">Maximum Y coordinate</param>
        /// <param name="srid">Spatial Reference System Identifier</param>
        /// <returns>Constructed geometry</returns>
        [Sql.Function("ST_MakeEnvelope", ServerSideOnly = true)]
        public static NTSG STMakeEnvelope(double xmin, double ymin, double xmax, double ymax, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a LineString containing the points of given geometries (Point, MultiPoint, or LineString).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakeLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Constructed geometry</returns>
        [Sql.Function("ST_MakeLine", ServerSideOnly = true)]
        public static NTSG STMakeLine(this NTSG geometry, NTSG other) // TODO: other versions
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs 2D Point geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakePoint.html
        /// </remarks>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_MakePoint", ServerSideOnly = true)]
        public static NTSG STMakePoint(double x, double y)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs 3D Z Point geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakePoint.html
        /// </remarks>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_MakePoint", ServerSideOnly = true)]
        public static NTSG STMakePoint(double x, double y, double z)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs 4D ZM Point geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakePoint.html
        /// </remarks>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="m">M coordinate (measure)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_MakePoint", ServerSideOnly = true)]
        public static NTSG STMakePoint(double x, double y, double z, double m)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs Point geometry with X, Y and M coordinates.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakePointM.html
        /// </remarks>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="m">M coordinate (measure)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_MakePointM", ServerSideOnly = true)]
        public static NTSG STMakePointM(double x, double y, double m)
        {
            throw new InvalidOperationException();
        }
    }
}