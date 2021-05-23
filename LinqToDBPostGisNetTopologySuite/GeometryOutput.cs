using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Output.
    /// </summary>
    /// <remarks>
    /// 5.9. Geometry Output
    /// https://postgis.net/docs/reference.html#Geometry_Outputs
    /// </remarks>
    public static class GeometryOutput
    {
        #region 5.9.1. Well-Known Text (WKT)
        /// <summary>
        /// Returns the Extended Well-Known Text (EWKT) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsEWKT.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Extended Well-Known Text (EWKT) representation, prefixed with the SRID.</returns>
        [Sql.Function("ST_AsEWKT", ServerSideOnly = true)]
        public static string STAsEWKT(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Extended Well-Known Text (EWKT) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsEWKT.html
        /// </remarks>
        /// <param name="geometry">Input geometry (binary representation as hexadecimal string).</param>
        /// <returns>Extended Well-Known Text (EWKT) representation, prefixed with the SRID.</returns>
        [Sql.Function("ST_AsEWKT", ServerSideOnly = true)]
        public static string STAsEWKT(string geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsEWKT(geography)
        // TODO: ST_AsEWKT(geometry, maxdecimaldigits) PostGIS 3.1

        /// <summary>
        /// Returns the Well-Known Text (WKT) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsText.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Well-Known Text (WKT) representation.</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Well-Known Text (WKT) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsText.html
        /// </remarks>
        /// <param name="geometry">Input geometry (binary representation as hexadecimal string).</param>
        /// <returns>Well-Known Text (WKT) representation.</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(string geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsText(geography)
        // TODO: ST_AsText(geography, maxdecimaldigits);

        /// <summary>
        /// Returns the Well-Known Text (WKT) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsText.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal digits after floating point used in output.</param>
        /// <returns>Well-Known Text (WKT) representation.</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this NTSG geometry, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }
        #endregion 5.9.1. Well-Known Text (WKT)

        #region 5.9.2. Well-Known Binary (WKB)
        /// <summary>
        /// Returns the Well-Known Binary (WKB) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsBinary.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Well-Known Binary (WKB) representation.</returns>
        [Sql.Function("ST_AsBinary", ServerSideOnly = true)]
        public static byte[] STAsBinary(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsBinary(geography)

        /// <summary>
        /// Returns the Well-Known Binary (WKB) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsBinary.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="encoding">Endianness encoding: little-endian ("NDR") or big-endian ("XDR").</param>
        /// <returns>Well-Known Binary (WKB) representation.</returns>
        [Sql.Function("ST_AsBinary", ServerSideOnly = true)]
        public static byte[] STAsBinary(this NTSG geometry, string encoding)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsBinary(geography, text)

        /// <summary>
        /// Returns the Extended Well-Known Binary (EWKB) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Extended Well-Known Binary (EWKB) representation.</returns>
        [Sql.Function("ST_AsEWKB", ServerSideOnly = true)]
        public static byte[] STAsEWKB(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Extended Well-Known Binary (EWKB) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="encoding">Endianness encoding: little-endian ("NDR") or big-endian ("XDR").</param>
        /// <returns>Extended Well-Known Binary (EWKB) representation.</returns>
        [Sql.Function("ST_AsEWKB", ServerSideOnly = true)]
        public static byte[] STAsEWKB(this NTSG geometry, string encoding)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the HEXEWKB representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsHEXEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>HEXEWKB representation.</returns>
        [Sql.Function("ST_AsHEXEWKB", ServerSideOnly = true)]
        public static string STAsHEXEWKB(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the HEXEWKB representation of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsHEXEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>HEXEWKB representation.</returns>
        [Sql.Function("ST_AsHEXEWKB", ServerSideOnly = true)]
        public static string STAsHEXEWKB(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the HEXEWKB representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsHEXEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="encoding">Endianness encoding: little-endian ("NDR") or big-endian ("XDR").</param>
        /// <returns>HEXEWKB representation.</returns>
        [Sql.Function("ST_AsHEXEWKB", ServerSideOnly = true)]
        public static string STAsHEXEWKB(this NTSG geometry, string encoding)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the HEXEWKB representation of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsHEXEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="encoding">Endianness encoding: little-endian ("NDR") or big-endian ("XDR").</param>
        /// <returns>HEXEWKB representation.</returns>
        [Sql.Function("ST_AsHEXEWKB", ServerSideOnly = true)]
        public static string STAsHEXEWKB(string geometry, string encoding)
        {
            throw new InvalidOperationException();
        }
        #endregion 5.9.2. Well-Known Binary (WKB)

        #region 5.9.3. Other Formats
        /// <summary>
        /// Returns the Encoded Polyline representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsEncodedPolyline.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Encoded Polyline representation.</returns>
        [Sql.Function("ST_AsEncodedPolyline", ServerSideOnly = true)]
        public static string STAsEncodedPolyline(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Encoded Polyline representation of input <paramref name="geometry"/> in text representation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsEncodedPolyline.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Encoded Polyline representation.</returns>
        [Sql.Function("ST_AsEncodedPolyline", ServerSideOnly = true)]
        public static string STAsEncodedPolyline(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Encoded Polyline representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsEncodedPolyline.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="precision">Number of decimal places in output (same as for decoding).</param>
        /// <returns>Encoded Polyline representation.</returns>
        [Sql.Function("ST_AsEncodedPolyline", ServerSideOnly = true)]
        public static string STAsEncodedPolyline(this NTSG geometry, int precision)
        {
            throw new InvalidOperationException();
        }

        // TODO: ? ST_AsGeobuf(anyelement set row) / ST_AsGeobuf(anyelement row, text geom_name)

        /// <summary>
        /// Returns the GeoJSON representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsGeoJSON.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>GeoJSON string representation.</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the GeoJSON representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsGeoJSON.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 9)</param>
        /// <returns>GeoJSON string representation.</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the GeoJSON representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsGeoJSON.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 9)</param>
        /// <param name="options">Options to add BBOX or CRS to output (defaults to 8 = GeoJSON Short CRS if not EPSG:4326)</param>
        /// <returns>GeoJSON string representation.</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry, int maxDecimalDigits, int options) // TODO: options enum (bitfield ?)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsGeoJSON(geography)

        /// <summary>
        /// Returns the GML representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsGML.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>GML string representation.</returns>
        [Sql.Function("ST_AsGML", ServerSideOnly = true)]
        public static string STAsGML(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the GML representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsGML.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15).</param>
        /// <param name="options">Options to add BBOX or CRS to output (defaults to 8 = GeoJSON Short CRS if not EPSG:4326).</param>
        /// <returns>GML string representation.</returns>
        [Sql.Function("ST_AsGML", ServerSideOnly = true)]
        public static string STAsGML(this NTSG geometry, int maxDecimalDigits, int options) // TODO: options enum (bitfield)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsGML(version, geometry)
        // TODO: ST_AsGML(geography)
        // TODO: ST_AsGML(version, geography)

        /// <summary>
        /// Returns the Keyhole Markup Language (KML) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsKML.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Keyhole Markup Language (KML) string representation.</returns>
        [Sql.Function("ST_AsKML", ServerSideOnly = true)]
        public static string STAsKML(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Keyhole Markup Language (KML) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsKML.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15).</param>
        /// <returns>Keyhole Markup Language (KML) string representation.</returns>
        [Sql.Function("ST_AsKML", ServerSideOnly = true)]
        public static string STAsKML(this NTSG geometry, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Keyhole Markup Language (KML) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsKML.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15).</param>
        /// <param name="nprefix">Prefix namespace.</param>
        /// <returns>Keyhole Markup Language (KML) string representation.</returns>
        [Sql.Function("ST_AsKML", ServerSideOnly = true)]
        public static string STAsKML(this NTSG geometry, int maxDecimalDigits, string nprefix)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsKML(geography)
        // TODO: ST_AsKML(version)

        /// <summary>
        /// Returns the Degrees, Minutes, Seconds (DMS) representation of input <paramref name="geometry"/> (Point).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsLatLonText.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <returns>DMS string.</returns>
        [Sql.Function("ST_AsLatLonText", ServerSideOnly = true)]
        public static string STAsLatLonText(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Degrees, Minutes, Seconds representation of input <paramref name="geometry"/> (Point).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsLatLonText.html
        /// </remarks>
        /// <param name="geometry">Input geometry (Point).</param>
        /// <param name="format">Custom format string.</param>
        /// <returns>DMS string.</returns>
        [Sql.Function("ST_AsLatLonText", ServerSideOnly = true)]
        public static string STAsLatLonText(this NTSG geometry, string format)
        {
            throw new InvalidOperationException();
        }

        // TODO: box2d NTS mapping implicit cast from geometry ?

        /// <summary>
        /// Transforms input <paramref name="geometry"/> into the coordinate space of a Mapbox Vector Tile of a set of rows corresponding to a Layer.
        /// </summary>
        /// <param name="geometry">Input geometry to transform.</param>
        /// <param name="bounds">Bounds of the tile contents without buffer.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_AsMVTGeom", ServerSideOnly = true)]
        public static NTSG STAsMVTGeom(this NTSG geometry, string bounds)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Transforms input <paramref name="geometry"/> into the coordinate space of a Mapbox Vector Tile of a set of rows corresponding to a Layer.
        /// </summary>
        /// <param name="geometry">Input geometry to transform.</param>
        /// <param name="bounds">Bounds of the tile contents without buffer.</param>
        /// <param name="extent">Tile extent in tile coordinate space (defaults to 4096).</param>
        /// <param name="buffer">Buffer distance in tile coordinate space to optionally clip geometries (defaults to 256).</param>
        /// <param name="clipGeometry">Geometries should be clipped or encoded as is (defaults to true).</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_AsMVTGeom", ServerSideOnly = true)]
        public static NTSG STAsMVTGeom(this NTSG geometry, string bounds, int extent, int buffer, bool clipGeometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsMVT(anyelement set row) ?

        /// <summary>
        /// Returns the Scalable Vector Graphics (SVG) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsSVG.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Scalable Vector Graphics (SVG) string representation.</returns>
        [Sql.Function("ST_AsSVG", ServerSideOnly = true)]
        public static string STAsSVG(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Scalable Vector Graphics (SVG) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsSVG.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="rel">Relative moves, if 1, otherwise absolute coordinates (defaults to 0).</param>
        /// <returns>Scalable Vector Graphics (SVG) string representation.</returns>
        [Sql.Function("ST_AsSVG", ServerSideOnly = true)]
        public static string STAsSVG(this NTSG geometry, int rel)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Scalable Vector Graphics (SVG) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsSVG.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="rel">Relative moves, if 1, otherwise absolute coordinates (defaults to 0).</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15).</param>
        /// <returns>Scalable Vector Graphics (SVG) string representation.</returns>
        [Sql.Function("ST_AsSVG", ServerSideOnly = true)]
        public static string STAsSVG(this NTSG geometry, int rel, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsSVG(geography)

        /// <summary>
        /// Returns the Tiny Well-Known Binary (TWKB) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsTWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Tiny Well-Known Binary (TWKB) representation.</returns>
        [Sql.Function("ST_AsTWKB", ServerSideOnly = true)]
        public static byte[] STAsTWKB(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Tiny Well-Known Binary (TWKB) representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsTWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="decimalDigitsXY">Decimal digits to store (XY coordinates).</param>
        /// <param name="decimalDigitsZ">Decimal digits to store (Z coordinate).</param>
        /// <param name="decimalDigitsM">Decimal digits to store (M coordinate).</param>
        /// <param name="includeSizes">Include sizes optional information.</param>
        /// <param name="includeBoundingBoxes">Include bounding boxes optional information.</param>
        /// <returns>Tiny Well-Known Binary (TWKB) representation.</returns>
        [Sql.Function("ST_AsTWKB", ServerSideOnly = true)]
        public static byte[] STAsTWKB(this NTSG geometry, int decimalDigitsXY, int decimalDigitsZ, int decimalDigitsM, bool includeSizes, bool includeBoundingBoxes)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsTWKB(geometry[] geometries) ?

        /// <summary>
        /// Returns the X3D representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsX3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>X3D XML node string.</returns>
        [Sql.Function("ST_AsX3D", ServerSideOnly = true)]
        public static string STAsX3D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns X3D representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsX3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15).</param>
        /// <returns>X3D XML node string.</returns>
        [Sql.Function("ST_AsX3D", ServerSideOnly = true)]
        public static string STAsX3D(this NTSG geometry, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns X3D representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AsX3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15).</param>
        /// <param name="options">Options bitfield.</param>
        /// <returns>X3D XML node string.</returns>
        [Sql.Function("ST_AsX3D", ServerSideOnly = true)]
        public static string STAsX3D(this NTSG geometry, int maxDecimalDigits, int options) // TODO: options enum (bitfield)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the GeoHash representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeoHash.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>GeoHash representation.</returns>
        [Sql.Function("ST_GeoHash", ServerSideOnly = true)]
        public static string STGeoHash(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns GeoHash representation of input <paramref name="geometry"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_GeoHash.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxchars">Maximum number of characters in output (precision).</param>
        /// <returns>GeoHash representation.</returns>
        [Sql.Function("ST_GeoHash", ServerSideOnly = true)]
        public static string STGeoHash(this NTSG geometry, int maxchars)
        {
            throw new InvalidOperationException();
        }
        #endregion 5.9.3. Other Formats
    }
}
