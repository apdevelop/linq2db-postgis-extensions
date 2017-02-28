using System;
using System.Globalization;

using LinqToDB;
using LinqToDB.Data;
using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Constructors

    public static class GeometryConstructors
    {
        [Sql.Function("ST_GeomFromEWKT", ServerSideOnly = true)]
        public static PostgisGeometry StGeomFromEWKT(string ewkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a specified geometry value from Extended Well-Known Text representation (EWKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromEWKT.html
        /// </summary>
        /// <param name="ewkt">Extended Well-Known Text representation (EWKT)</param>
        /// <returns>Geometry object</returns>
        public static PostgisGeometry StGeomFromEWKT(this DataConnection connection, string ewkt)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = String.Format(CultureInfo.InvariantCulture, "SELECT ST_GeomFromEWKT('{0}')", ewkt);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var geometry = reader[0] as PostgisGeometry;
                    return geometry;
                }
            }
        }

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
        public static PostgisGeometry StGeomFromText(this DataConnection connection, string wkt)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = String.Format(CultureInfo.InvariantCulture, "SELECT ST_GeomFromText('{0}')", wkt);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var geometry = reader[0] as PostgisGeometry;
                    return geometry;
                }
            }
        }

        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static PostgisGeometry StGeomFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a specified geometry value from Well-Known Text representation (WKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text representation (WKT)</param>
        /// <returns>Geometry object</returns>
        public static PostgisGeometry StGeomFromText(this DataConnection connection, string wkt, int srid)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = String.Format(CultureInfo.InvariantCulture, "SELECT ST_GeomFromText('{0}', {1})", wkt, srid);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var geometry = reader[0] as PostgisGeometry;
                    return geometry;
                }
            }
        }

        /// <summary>
        /// Creates a rectangular Polygon formed from the given minimums and maximums. Input values must be in SRS specified by the SRID.
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="ymin"></param>
        /// <param name="xmax"></param>
        /// <param name="ymax"></param>
        /// <param name="srid"></param>
        /// <returns></returns>
        [Sql.Function("ST_MakeEnvelope", ServerSideOnly = true)]
        public static PostgisGeometry StMakeEnvelope(double xmin, double ymin, double xmax, double ymax, int srid)
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
