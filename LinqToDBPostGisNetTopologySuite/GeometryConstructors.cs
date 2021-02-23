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
        /// <param name="srid">Spatial Reference System Identifier (SRID)</param>
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

        /// <summary>
        /// Constructs Polygon geometry formed by given shell.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MakePolygon.html
        /// </remarks>
        /// <param name="geometry">Input geometry (closed LineString)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_MakePolygon", ServerSideOnly = true)]
        public static NTSG STMakePolygon(this NTSG geometry) // TODO: with interiorlinestrings
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs 2D Point geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Point.html
        /// </remarks>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Geometry (Point)</returns>
        [Sql.Function("ST_Point", ServerSideOnly = true)]
        public static NTSG STPoint(double x, double y)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs Polygon geometry from given LineString.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Polygon.html
        /// </remarks>
        /// <param name="geometry">Input geometry (closed LineString)</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Polygon", ServerSideOnly = true)]
        public static NTSG STPolygon(this NTSG geometry, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs rectangular Polygon in Web Mercator (SRID:3857) using XYZ tile system.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_TileEnvelope.html
        /// </remarks>
        /// <param name="tileZoom">Tile Z</param>
        /// <param name="tileX">Tile X</param>
        /// <param name="tileY">Tile Y</param>         
        /// <returns>Geometry (Polygon)</returns>
        [Sql.Function("ST_TileEnvelope", ServerSideOnly = true)]
        public static NTSG STTileEnvelope(int tileZoom, int tileX, int tileY)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs rectangular Polygon in Web Mercator (SRID:3857) using XYZ tile system.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_TileEnvelope.html
        /// </remarks>
        /// <param name="tileZoom">Tile Z</param>
        /// <param name="tileX">Tile X</param>
        /// <param name="tileY">Tile Y</param>      
        /// <param name="bounds">Bounds</param>
        /// <returns>Geometry (Polygon)</returns>
        [Sql.Function("ST_TileEnvelope", ServerSideOnly = true)]
        public static NTSG STTileEnvelope(int tileZoom, int tileX, int tileY, NTSG bounds)
        {
            throw new InvalidOperationException();
        }
    }
}
