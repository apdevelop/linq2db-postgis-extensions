using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Input.
    /// </summary>
    /// <remarks>
    /// 5.8. Geometry Input
    /// https://postgis.net/docs/reference.html#Geometry_Inputs
    /// </remarks>
    public static class GeometryInput
    {
#pragma warning disable IDE0060
        #region 5.8.1. Well-Known Text (WKT)
        /// <summary>
        /// Constructs the geometry (Polygon) from arbitrary collection of closed LineStrings as MultiLineString Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_BdPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (Polygon).</returns>
        [Sql.Function("ST_BdPolyFromText", ServerSideOnly = true)]
        public static NTSG STBdPolyFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs the geometry (MultiPolygon) from arbitrary collection of closed LineStrings, Polygons, MultiLineStrings as Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_BdMPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (MultiPolygon).</returns>
        [Sql.Function("ST_BdMPolyFromText", ServerSideOnly = true)]
        public static NTSG STBdMPolyFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geography from Extended Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeogFromText.html
        /// </remarks>
        /// <param name="ewkt">Extended Well-Known Text (EWKT) string.</param>
        /// <returns>Geography.</returns>
        [Sql.Function("ST_GeogFromText", ServerSideOnly = true)]
        public static NTSG STGeogFromText(string ewkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geography from Extended Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeographyFromText.html
        /// </remarks>
        /// <param name="ewkt">Extended Well-Known Text (EWKT) string.</param>
        /// <returns>Geography.</returns>
        [Sql.Function("ST_GeographyFromText", ServerSideOnly = true)]
        public static NTSG STGeographyFromText(string ewkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (GeometryCollection) from Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomCollFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry (GeometryCollection).</returns>
        [Sql.Function("ST_GeomCollFromText", ServerSideOnly = true)]
        public static NTSG STGeomCollFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (GeometryCollection) from Well-Known Text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomCollFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (GeometryCollection).</returns>
        [Sql.Function("ST_GeomCollFromText", ServerSideOnly = true)]
        public static NTSG STGeomCollFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from Extended Well-Known Text (EWKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromEWKT.html
        /// </remarks>
        /// <param name="ewkt">Extended Well-Known Text (EWKT) string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromEWKT", ServerSideOnly = true)]
        public static NTSG STGeomFromEWKT(string ewkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometryFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeometryFromText", ServerSideOnly = true)]
        public static NTSG STGeometryFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeometryFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeometryFromText", ServerSideOnly = true)]
        public static NTSG STGeometryFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static NTSG STGeomFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static NTSG STGeomFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (LineString) from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry (LineString); null if WKT is not a LineString.</returns>
        [Sql.Function("ST_LineFromText", ServerSideOnly = true)]
        public static NTSG STLineFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (LineString) from OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (LineString); null if WKT is not a LineString.</returns>
        [Sql.Function("ST_LineFromText", ServerSideOnly = true)]
        public static NTSG STLineFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (MultiLineString) from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MLineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry (MultiLineString); null if WKT is not a MultiLineString.</returns>
        [Sql.Function("ST_MLineFromText", ServerSideOnly = true)]
        public static NTSG STMLineFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (MultiLineString) from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MLineFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (MultiLineString); null if WKT is not a MultiLineString.</returns>
        [Sql.Function("ST_MLineFromText", ServerSideOnly = true)]
        public static NTSG STMLineFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (MultiPoint) from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MPointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry (MultiPoint); null if WKT is not a MultiPoint.</returns>
        [Sql.Function("ST_MPointFromText", ServerSideOnly = true)]
        public static NTSG STMPointFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (MultiPoint) from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MPointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (MultiPoint); null if WKT is not a MultiPoint.</returns>
        [Sql.Function("ST_MPointFromText", ServerSideOnly = true)]
        public static NTSG STMPointFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (MultiPolygon) from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry (MultiPolygon); null if WKT is not a MultiPolygon.</returns>
        [Sql.Function("ST_MPolyFromText", ServerSideOnly = true)]
        public static NTSG STMPolyFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (MultiPolygon) from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MPolyFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (MultiPolygon); null if WKT is not a MultiPolygon.</returns>
        [Sql.Function("ST_MPolyFromText", ServerSideOnly = true)]
        public static NTSG STMPolyFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (Point) from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry (Point); null if WKT is not a Point.</returns>
        [Sql.Function("ST_PointFromText", ServerSideOnly = true)]
        public static NTSG STPointFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (Point) from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (Point); null if WKT is not a Point.</returns>
        [Sql.Function("ST_PointFromText", ServerSideOnly = true)]
        public static NTSG STPointFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (Polygon) from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PolygonFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry (Polygon); null if WKT is not a Polygon.</returns>
        [Sql.Function("ST_PolygonFromText", ServerSideOnly = true)]
        public static NTSG STPolygonFromText(string wkt) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (Polygon) from the OGC Well-Known Text (WKT) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PolygonFromText.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (Polygon); null if WKT is not a Polygon.</returns>
        [Sql.Function("ST_PolygonFromText", ServerSideOnly = true)]
        public static NTSG STPolygonFromText(string wkt, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC Well-Known Text (WKT) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_WKTToSQL.html
        /// </remarks>
        /// <param name="wkt">Well-Known Text (WKT) string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_WKTToSQL", ServerSideOnly = true)]
        public static NTSG STWKTToSQL(string wkt) => throw new InvalidOperationException();
        #endregion 5.8.1. Well-Known Text (WKT)

        #region 5.8.2. Well-Known Binary (WKB)
        /// <summary>
        /// Constructs geography from the Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeogFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB) or Extended WKB (EWKB).</param>
        /// <returns>Geography.</returns>
        [Sql.Function("ST_GeogFromWKB", ServerSideOnly = true)]
        public static NTSG STGeogFromWKB(byte[] wkb) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the Extended Well-Known Binary (EWKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromEWKB.html
        /// </remarks>
        /// <param name="ewkb">Extended Well-Known Binary (EWKB).</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromEWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromEWKB(byte[] ewkb) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromWKB(byte[] wkb) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromWKB(byte[] wkb, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (LineString) from the Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_LineFromWKB", ServerSideOnly = true)]
        public static NTSG STLineFromWKB(byte[] wkb) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (LineString) from the Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_LineFromWKB", ServerSideOnly = true)]
        public static NTSG STLineFromWKB(byte[] wkb, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (LineString) from the Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LinestringFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_LinestringFromWKB", ServerSideOnly = true)]
        public static NTSG STLinestringFromWKB(byte[] wkb) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (LineString) from the Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LinestringFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (LineString).</returns>
        [Sql.Function("ST_LinestringFromWKB", ServerSideOnly = true)]
        public static NTSG STLinestringFromWKB(byte[] wkb, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (Point) from the Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <returns>Geometry (Point).</returns>
        [Sql.Function("ST_PointFromWKB", ServerSideOnly = true)]
        public static NTSG STPointFromWKB(byte[] wkb) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry (Point) from the Well-Known Binary (WKB) representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointFromWKB.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry (Point).</returns>
        [Sql.Function("ST_PointFromWKB", ServerSideOnly = true)]
        public static NTSG STPointFromWKB(byte[] wkb, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the Well-Known Binary (WKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_WKBToSQL.html
        /// </remarks>
        /// <param name="wkb">Well-Known Binary (WKB).</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_WKBToSQL", ServerSideOnly = true)]
        public static NTSG STWKBToSQL(byte[] wkb) => throw new InvalidOperationException();
        #endregion 5.8.2. Well-Known Binary (WKB)

        #region 5.8.3. Other Formats
        // TODO: ST_Box2dFromGeoHash return type NTS mapping?
        // https://github.com/npgsql/efcore.pg/issues/1313#issuecomment-635202797

        /// <summary>
        /// Constructs Polygon geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string.</param>
        /// <returns>Polygon representing the GeoHash bounds.</returns>
        [Sql.Function("ST_GeomFromGeoHash", ServerSideOnly = true)]
        public static NTSG STGeomFromGeoHash(string geoHash) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs Polygon geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string.</param>
        /// <param name="precision">Number of characters to use from GeoHash.</param>
        /// <returns>Polygon representing the GeoHash bounds.</returns>
        [Sql.Function("ST_GeomFromGeoHash", ServerSideOnly = true)]
        public static NTSG STGeomFromGeoHash(string geoHash, int precision) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC GML string representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromGML.html
        /// </remarks>
        /// <param name="gml">GML string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromGML", ServerSideOnly = true)]
        public static NTSG STGeomFromGML(string gml) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC GML string representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromGML.html
        /// </remarks>
        /// <param name="gml">GML string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromGML", ServerSideOnly = true)]
        public static NTSG STGeomFromGML(string gml, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the GeoJSON string representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromGeoJSON.html
        /// </remarks>
        /// <param name="geoJson">GeoJSON string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromGeoJSON", ServerSideOnly = true)]
        public static NTSG STGeomFromGeoJSON(string geoJson) => throw new InvalidOperationException();

        // TODO: ? json / jsonb ?

        /// <summary>
        /// Constructs geometry from the OGC KML string representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromKML.html
        /// </remarks>
        /// <param name="kml">KML string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromKML", ServerSideOnly = true)]
        public static NTSG STGeomFromKML(string kml) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the Tiny Well-Known Binary (TWKB) representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeomFromTWKB.html
        /// </remarks>
        /// <param name="twkb">Tiny Well-Known Binary (TWKB).</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GeomFromTWKB", ServerSideOnly = true)]
        public static NTSG STGeomFromTWKB(byte[] twkb) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC GML representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GMLToSQL.html
        /// </remarks>
        /// <param name="gml">GML string.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GMLToSQL", ServerSideOnly = true)]
        public static NTSG STGMLToSQL(string gml) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs geometry from the OGC GML representation with given SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GMLToSQL.html
        /// </remarks>
        /// <param name="gml">GML string.</param>
        /// <param name="srid">Spatial Reference System Identifier (SRID) for geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_GMLToSQL", ServerSideOnly = true)]
        public static NTSG STGMLToSQL(string gml, int srid) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs LineString geometry from given Encoded Polyline string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromEncodedPolyline.html
        /// </remarks>
        /// <param name="polyline">Encoded Polyline string.</param>
        /// <returns>LineString geometry.</returns>
        [Sql.Function("ST_LineFromEncodedPolyline", ServerSideOnly = true)]
        public static NTSG STLineFromEncodedPolyline(string polyline) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs LineString geometry from given Encoded Polyline string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineFromEncodedPolyline.html
        /// </remarks>
        /// <param name="polyline">Encoded Polyline string.</param>
        /// <param name="precision">Number of characters to use from Encoded Polyline string.</param>
        /// <returns>LineString geometry.</returns>
        [Sql.Function("ST_LineFromEncodedPolyline", ServerSideOnly = true)]
        public static NTSG STLineFromEncodedPolyline(string polyline, int precision) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs Point geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string.</param>
        /// <returns>Geometry (center point of GeoHash).</returns>
        [Sql.Function("ST_PointFromGeoHash", ServerSideOnly = true)]
        public static NTSG STPointFromGeoHash(string geoHash) => throw new InvalidOperationException();

        /// <summary>
        /// Constructs Point geometry from given GeoHash string.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_PointFromGeoHash.html
        /// </remarks>
        /// <param name="geoHash">GeoHash string.</param>
        /// <param name="precision">Number of characters to use from GeoHash.</param>
        /// <returns>Geometry (center point of GeoHash).</returns>
        [Sql.Function("ST_PointFromGeoHash", ServerSideOnly = true)]
        public static NTSG STPointFromGeoHash(string geoHash, int precision) => throw new InvalidOperationException();
        #endregion 5.8.3. Other Formats
#pragma warning restore IDE0060
    }
}
