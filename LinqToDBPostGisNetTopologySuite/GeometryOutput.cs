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
        /// Returns the Well-Known Text representation of the geometry/geography.
        /// https://postgis.net/docs/manual-3.0/ST_AsText.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Well-Known Text</returns>
        [Sql.Function("ST_AsText", ServerSideOnly = true)]
        public static string STAsText(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}