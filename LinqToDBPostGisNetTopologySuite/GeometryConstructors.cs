using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Constructors.
    /// </summary>
    /// <remarks>
    /// 5.3. Geometry Constructors
    /// https://postgis.net/docs/reference.html#Geometry_Constructors
    /// </remarks>
    public static class GeometryConstructors
    {
        /// <summary>
        /// Creates a GeometryCollection or Multi* geometry from a set of input geometries.
        /// <para>The result is either a Multi* or a GeometryCollection, depending on whether the input geometries have the same or different types (homogeneous or heterogeneous).</para>
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Collect.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Geometry collection (Multi* or GeometryCollection).</returns>
        [Sql.Function("ST_Collect", ServerSideOnly = true)]
        public static NTSG STCollect(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a GeometryCollection or Multi* geometry from a set of input geometries in text representation.
        /// <para>The result is either a Multi* or a GeometryCollection, depending on whether the input geometries have the same or different types (homogeneous or heterogeneous).</para>
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Collect.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1.</param>
        /// <param name="geometry2">Input geometry 2.</param>
        /// <returns>Geometry collection (Multi* or GeometryCollection).</returns>
        [Sql.Function("ST_Collect", ServerSideOnly = true)]
        public static NTSG STCollect(string geometry1, string geometry2)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? geometry ST_Collect(geometry[] g1_array);
        // TODO: ? geometry ST_Collect(geometry set g1field);

        /// <summary>
        /// Creates a LineString geometry from a MultiPoint input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromMultiPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (MultiPoint).</param>
        /// <returns>Constructed geometry (LineString).</returns>
        [Sql.Function("ST_LineFromMultiPoint", ServerSideOnly = true)]
        public static NTSG STLineFromMultiPoint(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a LineString geometry from a MultiPoint input geometry in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromMultiPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (MultiPoint).</param>
        /// <returns>Constructed geometry (LineString).</returns>
        [Sql.Function("ST_LineFromMultiPoint", ServerSideOnly = true)]
        public static NTSG STLineFromMultiPoint(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a rectangular Polygon geometry from minimum and maximum values for X and Y.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakeEnvelope.html
        /// </remarks>
        /// <param name="xmin">Minimum X coordinate in unknown SRS (SRID 0) units.</param>
        /// <param name="ymin">Minimum Y coordinate in unknown SRS (SRID 0) units.</param>
        /// <param name="xmax">Maximum X coordinate in unknown SRS (SRID 0) units.</param>
        /// <param name="ymax">Maximum Y coordinate in unknown SRS (SRID 0) units.</param>
        /// <returns>Constructed geometry (Polygon).</returns>
        [Sql.Function("ST_MakeEnvelope", ServerSideOnly = true)]
        public static NTSG STMakeEnvelope(double xmin, double ymin, double xmax, double ymax)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a rectangular Polygon geometry from minimum and maximum values for X and Y.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakeEnvelope.html
        /// </remarks>
        /// <param name="xmin">Minimum X coordinate in SRS units, specified by the <paramref name="srid"/>.</param>
        /// <param name="ymin">Minimum Y coordinate in SRS units, specified by the <paramref name="srid"/>.</param>
        /// <param name="xmax">Maximum X coordinate in SRS units, specified by the <paramref name="srid"/>.</param>
        /// <param name="ymax">Maximum Y coordinate in SRS units, specified by the <paramref name="srid"/>.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID).</param>
        /// <returns>Constructed geometry (Polygon).</returns>
        [Sql.Function("ST_MakeEnvelope", ServerSideOnly = true)]
        public static NTSG STMakeEnvelope(double xmin, double ymin, double xmax, double ymax, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a LineString geometry containing the points of input geometries (Point, MultiPoint, or LineString).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakeLine.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1.</param>
        /// <param name="other">Input geometry 2.</param>
        /// <returns>Constructed geometry (LineString).</returns>
        [Sql.Function("ST_MakeLine", ServerSideOnly = true)]
        public static NTSG STMakeLine(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a LineString geometry containing the points of input geometries (Point, MultiPoint, or LineString).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakeLine.html
        /// </remarks>
        /// <param name="geometry1">Input geometry 1.</param>
        /// <param name="geometry2">Input geometry 2.</param>
        /// <returns>Constructed geometry (LineString).</returns>
        [Sql.Function("ST_MakeLine", ServerSideOnly = true)]
        public static NTSG STMakeLine(string geometry1, string geometry2)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? geometry ST_MakeLine(geometry[] geoms_array);
        // TODO: ? geometry ST_MakeLine(geometry set geoms);

        /// <summary>
        /// Creates a Point (2D) geometry from given X and Y coordinates.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakePoint.html
        /// </remarks>
        /// <seealso cref="STPoint(double, double)"/>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Geometry (2D Point).</returns>
        [Sql.Function("ST_MakePoint", ServerSideOnly = true)]
        public static NTSG STMakePoint(double x, double y)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a Point (3D Z) geometry from given X, Y and Z coordinates.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakePoint.html
        /// </remarks>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <returns>Geometry (3D Z Point).</returns>
        [Sql.Function("ST_MakePoint", ServerSideOnly = true)]
        public static NTSG STMakePoint(double x, double y, double z)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a Point (4D ZM) geometry from given X, Y, Z and M coordinates.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakePoint.html
        /// </remarks>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        /// <param name="m">M coordinate (measure).</param>
        /// <returns>Geometry (4D ZM Point).</returns>
        [Sql.Function("ST_MakePoint", ServerSideOnly = true)]
        public static NTSG STMakePoint(double x, double y, double z, double m)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a Point (2D M) geometry from given X, Y and M coordinates.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakePointM.html
        /// </remarks>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="m">M coordinate (measure).</param>
        /// <returns>Geometry (2D M Point).</returns>
        [Sql.Function("ST_MakePointM", ServerSideOnly = true)]
        public static NTSG STMakePointM(double x, double y, double m)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a Polygon geometry formed by the given shell geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakePolygon.html
        /// </remarks>
        /// <param name="geometry">Input shell geometry (closed LineString).</param>
        /// <returns>Geometry (Polygon).</returns>
        [Sql.Function("ST_MakePolygon", ServerSideOnly = true)]
        public static NTSG STMakePolygon(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? geometry ST_MakePolygon(geometry outerlinestring, geometry[] interiorlinestrings);

        /// <summary>
        /// Creates a Point (2D) geometry from given X and Y coordinates.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Point.html
        /// </remarks>
        /// <seealso cref="STMakePoint(double, double)"/>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Geometry (2D Point).</returns>
        [Sql.Function("ST_Point", ServerSideOnly = true)]
        public static NTSG STPoint(double x, double y)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a Polygon geometry from input LineString geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Polygon.html
        /// </remarks>
        /// <param name="geometry">Input geometry (closed LineString).</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID).</param>
        /// <returns>Geometry (Polygon).</returns>
        [Sql.Function("ST_Polygon", ServerSideOnly = true)]
        public static NTSG STPolygon(this NTSG geometry, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a Polygon geometry from input LineString geometry in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Polygon.html
        /// </remarks>
        /// <param name="geometry">Input geometry (closed LineString).</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID).</param>
        /// <returns>Geometry (Polygon).</returns>
        [Sql.Function("ST_Polygon", ServerSideOnly = true)]
        public static NTSG STPolygon(string geometry, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a rectangular Polygon geometry of tile in Web Mercator (SRID:3857) using the XYZ tile system with default bounds.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_TileEnvelope.html
        /// </remarks>
        /// <param name="tileZoom">Tile Z coordinate (zoom level).</param>
        /// <param name="tileX">Tile X coordinate.</param>
        /// <param name="tileY">Tile Y coordinate.</param>
        /// <returns>Geometry (Polygon).</returns>
        [Sql.Function("ST_TileEnvelope", ServerSideOnly = true)]
        public static NTSG STTileEnvelope(int tileZoom, int tileX, int tileY)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a rectangular Polygon geometry of tile in Web Mercator (SRID:3857) using the XYZ tile system with given <paramref name="bounds"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_TileEnvelope.html
        /// </remarks>
        /// <param name="tileZoom">Tile Z coordinate (zoom level).</param>
        /// <param name="tileX">Tile X coordinate.</param>
        /// <param name="tileY">Tile Y coordinate.</param>   
        /// <param name="bounds">Bounds.</param>
        /// <returns>Geometry (Polygon).</returns>
        [Sql.Function("ST_TileEnvelope", ServerSideOnly = true)]
        public static NTSG STTileEnvelope(int tileZoom, int tileX, int tileY, NTSG bounds)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates a rectangular Polygon geometry of tile in Web Mercator (SRID:3857) using the XYZ tile system with given <paramref name="bounds"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_TileEnvelope.html
        /// </remarks>
        /// <param name="tileZoom">Tile Z coordinate (zoom level).</param>
        /// <param name="tileX">Tile X coordinate.</param>
        /// <param name="tileY">Tile Y coordinate.</param>   
        /// <param name="bounds">Bounds.</param>
        /// <returns>Geometry (Polygon).</returns>
        [Sql.Function("ST_TileEnvelope", ServerSideOnly = true)]
        public static NTSG STTileEnvelope(int tileZoom, int tileX, int tileY, string bounds)
        {
            throw new InvalidOperationException();
        }
    }
}
