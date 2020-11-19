using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Input
    /// </summary>
    /// <remarks>
    /// 8.8. Geometry Input https://postgis.net/docs/manual-3.0/reference.html#Geometry_Inputs
    /// </remarks>
    public static class GeometryInput
    {
        // TODO: Complete 8.8.1. Well-Known Text (WKT)

        /// <summary>
        /// Constructs geometry from the Extended Well-Known Text (EWKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromEWKT.html
        /// </remarks>
        /// <param name="ewkt">Extended Well-Known Text (EWKT)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromEWKT", ServerSideOnly = true)]
        public static NTSG STGeomFromEWKT(string ewkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static NTSG STGeomFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static NTSG STGeomFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        // TODO: Implement 8.8.2. Well-Known Binary (WKB)

        #region 8.8.3. Other Formats

        // TODO: ST_Box2dFromGeoHash return type NTS mapping?

        /// <summary>
        /// Constructs Polygon geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string</param>
        /// <returns>Polygon representing the GeoHash bounds</returns>
        [Sql.Function("ST_GeomFromGeoHash", ServerSideOnly = true)]
        public static NTSG STGeomFromGeoHash(string geoHash)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs Polygon geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string</param>
        /// <param name="precision">Number of characters to use from GeoHash</param>
        /// <returns>Polygon representing the GeoHash bounds</returns>
        [Sql.Function("ST_GeomFromGeoHash", ServerSideOnly = true)]
        public static NTSG STGeomFromGeoHash(string geoHash, int precision)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from OGC GML representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromGML.html
        /// </remarks>
        /// <param name="gml">GML string</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromGML", ServerSideOnly = true)]
        public static NTSG STGeomFromGML(string gml)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from OGC GML representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromGML.html
        /// </remarks>
        /// <param name="gml">GML string</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromGML", ServerSideOnly = true)]
        public static NTSG STGeomFromGML(string gml, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from GeoJSON representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromGeoJSON.html
        /// </remarks>
        /// <param name="geoJson">GeoJSON string</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromGeoJSON", ServerSideOnly = true)]
        public static NTSG STGeomFromGeoJSON(string geoJson)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? json / jsonb ?

        /// <summary>
        /// Constructs geometry from OGC KML representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromKML.html
        /// </remarks>
        /// <param name="kml">KML string</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromKML", ServerSideOnly = true)]
        public static NTSG STGeomFromKML(string kml)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from Tiny Well-Known Binary (TWKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromTWKB.html
        /// </remarks>
        /// <param name="twkb">Tiny Well-Known Binary (TWKB)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromTWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromTWKB(byte[] twkb)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from OGC GML representation (Alias for STGeomFromGML).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GMLToSQL.html
        /// </remarks>
        /// <param name="gml">GML string</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GMLToSQL", ServerSideOnly = true)]
        public static NTSG STGMLToSQL(string gml)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from OGC GML representation with given SRID (Alias for STGeomFromGML).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GMLToSQL.html
        /// </remarks>
        /// <param name="gml">GML string</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GMLToSQL", ServerSideOnly = true)]
        public static NTSG STGMLToSQL(string gml, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs LineString geometry from given Encoded Polyline string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineFromEncodedPolyline.html
        /// </remarks>
        /// <param name=" polyline">Encoded Polyline string</param>
        /// <returns>LineString geometry</returns>
        [Sql.Function("ST_LineFromEncodedPolyline", ServerSideOnly = true)]
        public static NTSG STLineFromEncodedPolyline(string polyline)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs LineString geometry from given Encoded Polyline string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineFromEncodedPolyline.html
        /// </remarks>
        /// <param name=" polyline">Encoded Polyline string</param>
        /// <param name="precision">Number of characters to use from Encoded Polyline string</param>
        /// <returns>LineString geometry</returns>
        [Sql.Function("ST_LineFromEncodedPolyline", ServerSideOnly = true)]
        public static NTSG STLineFromEncodedPolyline(string polyline, int precision)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs Point geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string</param>
        /// <returns>Geometry (center point of GeoHash)</returns>
        [Sql.Function("ST_PointFromGeoHash", ServerSideOnly = true)]
        public static NTSG STPointFromGeoHash(string geoHash)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs Point geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string</param>
        /// <param name="precision">Number of characters to use from GeoHash</param>
        /// <returns>Geometry (center point of GeoHash)</returns>
        [Sql.Function("ST_PointFromGeoHash", ServerSideOnly = true)]
        public static NTSG STPointFromGeoHash(string geoHash, int precision)
        {
            throw new InvalidOperationException();
        }

        #endregion
    }
}