using System;

using LinqToDB;
using NpgsqlTypes;

namespace LinqToDBPostGisNpgsqlTypes
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Outputs
    public static class GeometryOutputs
    {
#pragma warning disable IDE0060
        /// <summary>
        /// Return the Well-Known Binary (WKB) representation of the geometry without SRID meta data.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_AsBinary.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Well-Known Binary (WKB) representation of the geometry</returns>
        [Sql.Function("ST_AsBinary", ServerSideOnly = true)]
        public static byte[] STAsBinary(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the Extended Well-Known Text (EWKT) representation of the geometry with SRID meta data.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_AsEWKT.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Extended Well-Known Text (EWKT) representation of the geometry</returns>
        [Sql.Function("ST_AsEWKT", ServerSideOnly = true)]
        public static string STAsEWKT(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the geometry as a GeoJSON element.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_AsGeoJSON.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>GeoJSON representation of the geometry</returns>
        [Sql.Function("ST_AsGeoJSON", ServerSideOnly = true)]
        public static string STAsGeoJSON(this PostgisGeometry geom) => throw new InvalidOperationException();

        /// <summary>
        /// Return the Well-Known Text (WKT) representation of the geometry without SRID metadata.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_AsText.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Well-Known Text (WKT) representation of the geometry</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this PostgisGeometry geom) => throw new InvalidOperationException();
#pragma warning restore IDE0060
    }
}
