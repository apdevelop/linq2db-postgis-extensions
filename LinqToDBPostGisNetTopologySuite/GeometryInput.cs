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
        #region 8.8.1. Well-Known Text (WKT)

        /// <summary>
        /// Constructs geometry (POLYGON) from arbitrary collection of closed linestrings as MultiLineString Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_BdPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_BdPolyFromText", ServerSideOnly = true)]
        public static NTSG STBdPolyFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (MULTIPOLYGON) from arbitrary collection of closed LineStrings, Polygons, MultiLineStrings as Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_BdMPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (MULTIPOLYGON)</returns>
        [Sql.Function("ST_BdMPolyFromText", ServerSideOnly = true)]
        public static NTSG STBdMPolyFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        // TODO: geography ST_GeogFromText(text EWKT);
        // TODO: geography ST_GeographyFromText(text EWKT);

        /// <summary>
        /// Constructs geometry (GEOMETRYCOLLECTION) from Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomCollFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry (GEOMETRYCOLLECTION)</returns>
        [Sql.Function("ST_GeomCollFromText", ServerSideOnly = true)]
        public static NTSG STGeomCollFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (GEOMETRYCOLLECTION) from Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomCollFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (GEOMETRYCOLLECTION)</returns>
        [Sql.Function("ST_GeomCollFromText", ServerSideOnly = true)]
        public static NTSG STGeomCollFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from Extended Well-Known Text (EWKT) representation.
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
        /// Constructs geometry from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeometryFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeometryFromText", ServerSideOnly = true)]
        public static NTSG STGeometryFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeometryFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeometryFromText", ServerSideOnly = true)]
        public static NTSG STGeometryFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from OGC Well-Known Text (WKT) representation.
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

        /// <summary>
        /// Constructs geometry (LINESTRING) from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry (LINESTRING); null if WKT is not a LINESTRING</returns>
        [Sql.Function("ST_LineFromText", ServerSideOnly = true)]
        public static NTSG STLineFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (LINESTRING) from OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (LINESTRING); null if WKT is not a LINESTRING</returns>
        [Sql.Function("ST_LineFromText", ServerSideOnly = true)]
        public static NTSG STLineFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (MULTILINESTRING) from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MLineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry (MULTILINESTRING); null if WKT is not a MULTILINESTRING</returns>
        [Sql.Function("ST_MLineFromText", ServerSideOnly = true)]
        public static NTSG STMLineFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (MULTILINESTRING) from OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MLineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (MULTILINESTRING); null if WKT is not a MULTILINESTRING</returns>
        [Sql.Function("ST_MLineFromText", ServerSideOnly = true)]
        public static NTSG STMLineFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (MULTIPOINT) from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MPointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry (MULTIPOINT); null if WKT is not a MULTIPOINT</returns>
        [Sql.Function("ST_MPointFromText", ServerSideOnly = true)]
        public static NTSG STMPointFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (MULTIPOINT) from OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MPointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (MULTIPOINT); null if WKT is not a MULTIPOINT</returns>
        [Sql.Function("ST_MPointFromText", ServerSideOnly = true)]
        public static NTSG STMPointFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (MULTIPOLYGON) from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry (MULTIPOLYGON); null if WKT is not a MULTIPOLYGON</returns>
        [Sql.Function("ST_MPolyFromText", ServerSideOnly = true)]
        public static NTSG STMPolyFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (MULTIPOLYGON) from OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_MPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (MULTIPOLYGON); null if WKT is not a MULTIPOLYGON</returns>
        [Sql.Function("ST_MPolyFromText", ServerSideOnly = true)]
        public static NTSG STMPolyFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (POINT) from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry (POINT); null if WKT is not a POINT</returns>
        [Sql.Function("ST_PointFromText", ServerSideOnly = true)]
        public static NTSG STPointFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (POINT) from OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (POINT); null if WKT is not a POINT</returns>
        [Sql.Function("ST_PointFromText", ServerSideOnly = true)]
        public static NTSG STPointFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (POLYGON) from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PolygonFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry (POLYGON); null if WKT is not a POLYGON</returns>
        [Sql.Function("ST_PolygonFromText", ServerSideOnly = true)]
        public static NTSG STPolygonFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (POLYGON) from OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PolygonFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (POLYGON); null if WKT is not a POLYGON</returns>
        [Sql.Function("ST_PolygonFromText", ServerSideOnly = true)]
        public static NTSG STPolygonFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_WKTToSQL.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_WKTToSQL", ServerSideOnly = true)]
        public static NTSG STWKTToSQL(string wkt)
        {
            throw new InvalidOperationException();
        }

        #endregion

        #region 8.8.2. Well-Known Binary (WKB)

        // TODO: geography ST_GeogFromWKB(bytea wkb);

        /// <summary>
        /// Constructs geometry from Extended Well-Known Binary (EWKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromEWKB.html
        /// </remarks>
        /// <param name="ewkb">Extended Well-Known Binary (EWKB)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromEWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromEWKB(byte[] ewkb)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromWKB(byte[] wkb)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeomFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromWKB(byte[] wkb, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (LINESTRING) from Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <returns>Geometry (LINESTRING)</returns>
        [Sql.Function("ST_LineFromWKB", ServerSideOnly = true)]
        public static NTSG STLineFromWKB(byte[] wkb)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (LINESTRING) from Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (LINESTRING)</returns>
        [Sql.Function("ST_LineFromWKB", ServerSideOnly = true)]
        public static NTSG STLineFromWKB(byte[] wkb, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (LINESTRING) from Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LinestringFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <returns>Geometry (LINESTRING)</returns>
        [Sql.Function("ST_LinestringFromWKB", ServerSideOnly = true)]
        public static NTSG STLinestringFromWKB(byte[] wkb)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (LINESTRING) from Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LinestringFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (LINESTRING)</returns>
        [Sql.Function("ST_LinestringFromWKB", ServerSideOnly = true)]
        public static NTSG STLinestringFromWKB(byte[] wkb, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (POINT) from Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <returns>Geometry (POINT)</returns>
        [Sql.Function("ST_PointFromWKB", ServerSideOnly = true)]
        public static NTSG STPointFromWKB(byte[] wkb)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry (POINT) from Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_PointFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <param name="srid">Spatial Reference System Identifier for geometry</param>
        /// <returns>Geometry (POINT)</returns>
        [Sql.Function("ST_PointFromWKB", ServerSideOnly = true)]
        public static NTSG STPointFromWKB(byte[] wkb, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs geometry from Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_WKBToSQL.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_WKBToSQL", ServerSideOnly = true)]
        public static NTSG STWKBToSQL(byte[] wkb)
        {
            throw new InvalidOperationException();
        }

        #endregion

        #region 8.8.3. Other Formats

        // TODO: ST_Box2dFromGeoHash return type NTS mapping?
        // https://github.com/npgsql/efcore.pg/issues/1313#issuecomment-635202797

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