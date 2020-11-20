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
        /// <summary>
        /// Returns the Extended Well-Known Text representation of the geometry prefixed with the SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsEWKT.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Extended Well-Known Text</returns>
        [Sql.Function("ST_AsEWKT", ServerSideOnly = true)]
        public static string STAsEWKT(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Well-Known Text representation of the geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsText.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Well-Known Text</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Well-Known Binary (WKB) representation of the geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsBinary.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Well-Known Binary</returns>
        [Sql.Function("ST_AsBinary", ServerSideOnly = true)]
        public static byte[] STAsBinary(this NTSG geometry) // TODO: NDR_or_XDR version 
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Extended Well-Known Binary (EWKB) representation of the geometry.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsEWKB.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Extended Well-Known Binary</returns>
        [Sql.Function("ST_AsEWKB", ServerSideOnly = true)]
        public static byte[] STAsEWKB(this NTSG geometry) // TODO: NDR_or_XDR version 
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry as GeoJSON "geometry" object.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AsGeoJSON.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>GeoJSON</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry) // TODO: maxdecimaldigits, options
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns GeoHash representation of given geometry
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
        /// Returns GeoHash representation of given geometry
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_GeoHash.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="maxchars">Maximum number of characters (precision)</param>
        /// <returns>GeoHash</returns>
        [Sql.Function("ST_GeoHash", ServerSideOnly = true)]
        public static string STGeoHash(this NTSG geometry, int maxchars)
        {
            throw new InvalidOperationException();
        }
    }
}