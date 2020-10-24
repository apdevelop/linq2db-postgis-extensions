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
        /// <param name="srid">SRID of geometry</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static NTSG STGeomFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }
    }
}