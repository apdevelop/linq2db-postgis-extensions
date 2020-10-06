using System;

using LinqToDB;
using LinqToDB.Data;
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
        public static PostgisGeometry STGeomFromEWKT(string ewkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a specified geometry value from Extended Well-Known Text representation (EWKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromEWKT.html
        /// </summary>
        /// <param name="ewkt">Extended Well-Known Text representation (EWKT)</param>
        /// <returns>Geometry object</returns>
        public static PostgisGeometry STGeomFromEWKT(this DataConnection connection, string ewkt)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ST_GeomFromEWKT(@ewkt)";
                var paramEwkt = command.CreateParameter();
                paramEwkt.ParameterName = "ewkt";
                paramEwkt.Value = ewkt;
                command.Parameters.Add(paramEwkt);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var geometry = reader[0] as PostgisGeometry;
                    return geometry;
                }
            }
        }

        /// <summary>
        /// Return a specified geometry value from Well-Known Text representation (WKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text representation (WKT)</param>
        /// <returns>Geometry object</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static PostgisGeometry STGeomFromText(string wkt)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a specified geometry value from Well-Known Text representation (WKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text representation (WKT)</param>
        /// <returns>Geometry object</returns>
        public static PostgisGeometry STGeomFromText(this DataConnection connection, string wkt)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ST_GeomFromText(@wkt)";
                var paramWkt = command.CreateParameter();
                paramWkt.ParameterName = "wkt";
                paramWkt.Value = wkt;
                command.Parameters.Add(paramWkt);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var geometry = reader[0] as PostgisGeometry;
                    return geometry;
                }
            }
        }

        /// <summary>
        /// Return a specified geometry value from Well-Known Text representation (WKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text representation (WKT)</param>
        /// <returns>Geometry object</returns>
        [Sql.Function("ST_GeomFromText", ServerSideOnly = true)]
        public static PostgisGeometry STGeomFromText(string wkt, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a specified geometry value from Well-Known Text representation (WKT).
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_GeomFromText.html
        /// </summary>
        /// <param name="wkt">Well-Known Text representation (WKT)</param>
        /// <returns>Geometry object</returns>
        public static PostgisGeometry STGeomFromText(this DataConnection connection, string wkt, int srid)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ST_GeomFromText(@wkt, @srid)";
                var paramWkt = command.CreateParameter();
                paramWkt.ParameterName = "wkt";
                paramWkt.Value = wkt;
                command.Parameters.Add(paramWkt);
                var paramSrId = command.CreateParameter();
                paramSrId.ParameterName = "srid";
                paramSrId.Value = srid;
                command.Parameters.Add(paramSrId);
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
        public static PostgisGeometry STMakeEnvelope(double xmin, double ymin, double xmax, double ymax, int srid)
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
        public static PostgisGeometry STPoint(double x, double y)
        {
            throw new InvalidOperationException();
        }
    }
}