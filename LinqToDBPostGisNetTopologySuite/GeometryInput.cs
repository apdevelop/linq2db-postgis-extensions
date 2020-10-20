using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    // Chapter 8. PostGIS Reference
    // https://postgis.net/docs/manual-3.0/reference.html

    /// <summary>
    /// 8.8. Geometry Output
    /// https://postgis.net/docs/manual-3.0/reference.html#Geometry_Inputs
    /// </summary>
    public static class GeometryInput
    {
        /// <summary>
        /// Constructs a PostGIS ST_Geometry object from the OGC Extended Well-Known Text (EWKT) representation.
        /// https://postgis.net/docs/manual-3.0/ST_GeomFromEWKT.html
        /// </summary>
        /// <param name="ewkt">Extended Well-Known Text (EWKT)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromEWKT", ServerSideOnly = true)]
        public static NTSG STGeomFromEWKT(string ewkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs a PostGIS ST_Geometry object from the OGC Well-Known Text (WKT) representation.
        /// https://postgis.net/docs/manual-3.0/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text (WKT)</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static NTSG STGeomFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Constructs a PostGIS ST_Geometry object from the OGC Well-Known Text (WKT) representation.
        /// https://postgis.net/docs/manual-3.0/ST_GeomFromText.html
        /// </summary>
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