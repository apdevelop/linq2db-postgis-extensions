using System;

using LinqToDB;
using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Editors

    public static class GeometryEditors
    {
        /// <summary>
        /// Sets the SRID on a geometry to a particular integer value.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_SetSRID.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <param name="srid">Spatial reference system ID</param>
        /// <returns></returns>
        [Sql.Function("ST_SetSRID", ServerSideOnly = true)]
        public static PostgisGeometry StSetSrId(this PostgisGeometry geom, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a new geometry with its coordinates transformed to the SRID referenced by the integer parameter.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_Transform.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <param name="srid">Spatial reference system ID</param>
        /// <returns>Transformed geometry</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static PostgisGeometry StTransform(this PostgisGeometry geom, int srid)
        {
            throw new InvalidOperationException();
        }
    }
}
