using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Outputs

    public static class GeometryOutputs
    {
        /// <summary>
        /// Return the Extended Well-Known Text (EWKT) representation of the geometry with SRID meta data.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_AsEWKT.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>Extended Well-Known Text (EWKT) representation</returns>
        [LinqToDB.Sql.Function("ST_AsEWKT", ServerSideOnly = true)]
        public static string StAsEWKT(this PostgisGeometry geom)
        {
            return (string)(object)geom;
        }
    }
}
