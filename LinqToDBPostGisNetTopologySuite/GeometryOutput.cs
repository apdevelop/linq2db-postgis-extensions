using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    // Chapter 8. PostGIS Reference
    // https://postgis.net/docs/manual-3.0/reference.html

    /// <summary>
    /// 8.9. Geometry Output
    /// https://postgis.net/docs/manual-3.0/reference.html#Geometry_Outputs
    /// </summary>
    public static class GeometryOutput
    {
        /// <summary>
        /// Returns the Extended Well-Known Text representation of the geometry prefixed with the SRID.
        /// https://postgis.net/docs/manual-3.0/ST_AsEWKT.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Extended Well-Known Text</returns>
        [Sql.Function("ST_AsEWKT", ServerSideOnly = true)]
        public static string STAsEWKT(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Well-Known Text representation of the geometry.
        /// https://postgis.net/docs/manual-3.0/ST_AsText.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Well-Known Text</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the Well-Known Binary representation of the geometry.
        /// https://postgis.net/docs/manual-3.0/ST_AsBinary.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Well-Known Binary</returns>
        [Sql.Function("ST_AsBinary", ServerSideOnly = true)]
        public static byte[] STAsBinary(this NTSG geometry) // TODO: NDR_or_XDR version 
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return the geometry as a GeoJSON "geometry" object.
        /// https://postgis.net/docs/manual-3.0/ST_AsGeoJSON.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>GeoJSON</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this NTSG geometry) // TODO: maxdecimaldigits, options
        {
            throw new InvalidOperationException();
        }
    }
}