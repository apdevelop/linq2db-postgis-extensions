using System;

using LinqToDB;
using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Constructors

    public static class GeometryConstructors
    {
        /// <summary>
        /// Return a specified geometry value from Extended Well-Known Text representation (EWKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromEWKT.html
        /// </summary>
        /// <param name="ewkt">Extended Well-Known Text representation (EWKT)</param>
        /// <returns>Geometry object</returns>
        [Sql.Function("ST_GeomFromEWKT", ServerSideOnly = true)]
        public static PostgisGeometry StGeomFromEWKT(string ewkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a specified geometry value from Well-Known Text representation (WKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text representation (WKT)</param>
        /// <returns>Geometry object</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static PostgisGeometry StGeomFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a specified geometry value from Well-Known Text representation (WKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text representation (WKT)</param>
        /// <returns>Geometry object</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static PostgisGeometry StGeomFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns an ST_Point with the given coordinate values. OGC alias for ST_MakePoint.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [Sql.Function("ST_Point", ServerSideOnly = true)]
        public static PostgisGeometry StPoint(double x, double y)
        {
            throw new InvalidOperationException();
        }
    }
}
