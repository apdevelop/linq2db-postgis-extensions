using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Output
    /// </summary>
    /// <remarks>
    /// 8.9. Geometry Output https://postgis.net/docs/manual-3.0/reference.html#Geometry_Outputs
    /// </remarks>
    public static class GeometryOutput
    {
        #region 8.9.1. Well-Known Text (WKT)

        /// <summary>
        /// Returns Extended Well-Known Text (EWKT) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsEWKT.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Extended Well-Known Text (EWKT)</returns>
        [Sql.Function("ST_AsEWKT", ServerSideOnly = true)]
        public static string STAsEWKT(this NTSG geometry) // TODO: geography
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Well-Known Text (WKT) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsText.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Well-Known Text (WKT)</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this NTSG geometry) // TODO: geography
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Well-Known Text (WKT) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsText.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal digits after floating point used in output</param>
        /// <returns>Well-Known Text (WKT)</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this NTSG geometry, int maxDecimalDigits) // TODO: geography
        {
            throw new InvalidOperationException();
        }

        #endregion

        #region 8.9.2. Well-Known Binary (WKB)

        /// <summary>
        /// Returns Well-Known Binary (WKB) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsBinary.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Well-Known Binary (WKB)</returns>
        [Sql.Function("ST_AsBinary", ServerSideOnly = true)]
        public static byte[] STAsBinary(this NTSG geometry) // TODO: geography
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Well-Known Binary (WKB) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsBinary.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="encoding">Endianness encoding: little-endian ("NDR") or big-endian ("XDR")</param>
        /// <returns>Well-Known Binary (WKB)</returns>
        [Sql.Function("ST_AsBinary", ServerSideOnly = true)]
        public static byte[] STAsBinary(this NTSG geometry, string encoding) // TODO: geography
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Extended Well-Known Binary (EWKB) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Extended Well-Known Binary (EWKB)</returns>
        [Sql.Function("ST_AsEWKB", ServerSideOnly = true)]
        public static byte[] STAsEWKB(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Extended Well-Known Binary (EWKB) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="encoding">Endianness encoding: little-endian ("NDR") or big-endian ("XDR")</param>
        /// <returns>Extended Well-Known Binary (EWKB)</returns>
        [Sql.Function("ST_AsEWKB", ServerSideOnly = true)]
        public static byte[] STAsEWKB(this NTSG geometry, string encoding)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns HEXEWKB representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsHEXEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>HEXEWKB</returns>
        [Sql.Function("ST_AsHEXEWKB", ServerSideOnly = true)]
        public static string STAsHEXEWKB(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns HEXEWKB representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsHEXEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="encoding">Endianness encoding: little-endian ("NDR") or big-endian ("XDR")</param>
        /// <returns>HEXEWKB</returns>
        [Sql.Function("ST_AsHEXEWKB", ServerSideOnly = true)]
        public static string STAsHEXEWKB(this NTSG geometry, string encoding)
        {
            throw new InvalidOperationException();
        }

        #endregion

        #region 8.9.3. Other Formats

        /// <summary>
        /// Returns Encoded Polyline representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsEncodedPolyline.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Encoded Polyline</returns>
        [Sql.Function("ST_AsEncodedPolyline", ServerSideOnly = true)]
        public static string STAsEncodedPolyline(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Encoded Polyline representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsEncodedPolyline.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="precision">Number of decimal places in output (same as for decoding)</param>
        /// <returns>Encoded Polyline</returns>
        [Sql.Function("ST_AsEncodedPolyline", ServerSideOnly = true)]
        public static string STAsEncodedPolyline(this NTSG geometry, int precision)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_AsGeobuf

        /// <summary>
        /// Returns GeoJSON representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsGeoJSON.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>GeoJSON string</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns GeoJSON representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsGeoJSON.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 9)</param>
        /// <returns>GeoJSON string</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns GeoJSON representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsGeoJSON.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 9)</param>
        /// <param name="options">Options to add BBOX or CRS to output (defaults to 8 = GeoJSON Short CRS if not EPSG:4326)</param>
        /// <returns>GeoJSON string</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry, int maxDecimalDigits, int options) // TODO: options enum (bitfield ?)
        {
            throw new InvalidOperationException();
        }

        // TODO: geography

        /// <summary>
        /// Returns GML representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsGML.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>GML string</returns>
        [Sql.Function("ST_AsGML", ServerSideOnly = true)]
        public static string STAsGML(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns GML representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsGML.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15)</param>
        /// <param name="options">Options to add BBOX or CRS to output (defaults to 8 = GeoJSON Short CRS if not EPSG:4326)</param>
        /// <returns>GML string</returns>
        [Sql.Function("ST_AsGML", ServerSideOnly = true)]
        public static string STAsGML(this NTSG geometry, int maxDecimalDigits, int options) // TODO: options enum (bitfield)
        {
            throw new InvalidOperationException();
        }

        // TODO: geography
        // TODO: int version

        /// <summary>
        /// Returns Keyhole Markup Language (KML) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsKML.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Keyhole Markup Language (KML) string</returns>
        [Sql.Function("ST_AsKML", ServerSideOnly = true)]
        public static string STAsKML(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Keyhole Markup Language (KML) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsKML.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15)</param>
        /// <returns>Keyhole Markup Language (KML) string</returns>
        [Sql.Function("ST_AsKML", ServerSideOnly = true)]
        public static string STAsKML(this NTSG geometry, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Keyhole Markup Language (KML) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsKML.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15)</param>
        /// <param name="nprefix">Prefix namespace</param>
        /// <returns>Keyhole Markup Language (KML) string</returns>
        [Sql.Function("ST_AsKML", ServerSideOnly = true)]
        public static string STAsKML(this NTSG geometry, int maxDecimalDigits, string nprefix)
        {
            throw new InvalidOperationException();
        }

        // TODO: geography
        // TODO: version 2

        /// <summary>
        /// Returns Degrees, Minutes, Seconds representation of input Point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsLatLonText.html
        /// </remarks>
        /// <param name="geometry">Input geometry (POINT)</param>
        /// <returns>DMS string</returns>
        [Sql.Function("ST_AsLatLonText", ServerSideOnly = true)]
        public static string STAsLatLonText(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Degrees, Minutes, Seconds representation of input Point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsLatLonText.html
        /// </remarks>
        /// <param name="geometry">Input geometry (POINT)</param>
        /// <param name="format">Custom format string</param>
        /// <returns>DMS string</returns>
        [Sql.Function("ST_AsLatLonText", ServerSideOnly = true)]
        public static string STAsLatLonText(this NTSG geometry, string format)
        {
            throw new InvalidOperationException();
        }

        // TODO: box2d NTS mapping implicit cast from geometry 

        ////[Sql.Function("ST_AsMVTGeom", ServerSideOnly = true)]
        ////public static NTSG STAsMVTGeom(this NTSG geometry)
        ////{
        ////    throw new InvalidOperationException();
        ////}

        // TODO: ST_AsMVT

        /// <summary>
        /// Returns Scalable Vector Graphics (SVG) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsSVG.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Scalable Vector Graphics (SVG) string</returns>
        [Sql.Function("ST_AsSVG", ServerSideOnly = true)]
        public static string STAsSVG(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Scalable Vector Graphics (SVG) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsSVG.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rel">Relative moves, if 1, otherwise absolute coordinates (defaults to 0)</param>
        /// <returns>Scalable Vector Graphics (SVG) string</returns>
        [Sql.Function("ST_AsSVG", ServerSideOnly = true)]
        public static string STAsSVG(this NTSG geometry, int rel)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Scalable Vector Graphics (SVG) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsSVG.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="rel">Relative moves, if 1, otherwise absolute coordinates (defaults to 0)</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15)</param>
        /// <returns>Scalable Vector Graphics (SVG) string</returns>
        [Sql.Function("ST_AsSVG", ServerSideOnly = true)]
        public static string STAsSVG(this NTSG geometry, int rel, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns Tiny Well-Known Binary (TWKB) representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsTWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Tiny Well-Known Binary (TWKB)</returns>
        [Sql.Function("ST_AsTWKB", ServerSideOnly = true)]
        public static byte[] STAsTWKB(this NTSG geometry) // TODO: overloads
        {
            throw new InvalidOperationException();
        }

        // TODO: ? geometry[]

        /// <summary>
        /// Returns X3D representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsX3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>X3D XML node string</returns>
        [Sql.Function("ST_AsX3D", ServerSideOnly = true)]
        public static string STAsX3D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns X3D representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsX3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15)</param>
        /// <returns>X3D XML node string</returns>
        [Sql.Function("ST_AsX3D", ServerSideOnly = true)]
        public static string STAsX3D(this NTSG geometry, int maxDecimalDigits)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns X3D representation of input geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsX3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxDecimalDigits">Maximum number of decimal places used in output (defaults to 15)</param>
        /// <param name="options">Options bitfield</param>
        /// <returns>X3D XML node string</returns>
        [Sql.Function("ST_AsX3D", ServerSideOnly = true)]
        public static string STAsX3D(this NTSG geometry, int maxDecimalDigits, int options) // TODO: options enum (bitfield)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns GeoHash representation of input geometry
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeoHash.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>GeoHash</returns>
        [Sql.Function("ST_GeoHash", ServerSideOnly = true)]
        public static string STGeoHash(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns GeoHash representation of input geometry
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeoHash.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxchars">Maximum number of characters in output (precision)</param>
        /// <returns>GeoHash</returns>
        [Sql.Function("ST_GeoHash", ServerSideOnly = true)]
        public static string STGeoHash(this NTSG geometry, int maxchars)
        {
            throw new InvalidOperationException();
        }

        #endregion
    }
}