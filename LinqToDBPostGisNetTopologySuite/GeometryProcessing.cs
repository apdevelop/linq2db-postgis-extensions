using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    // Chapter 8. PostGIS Reference
    // https://postgis.net/docs/manual-3.0/reference.html

    /// <summary>
    /// 8.13. Geometry Processing
    /// https://postgis.net/docs/manual-3.0/reference.html#Geometry_Processing
    /// </summary>
    public static class GeometryProcessing
    {
        /// <summary>
        /// Returns a geometry that represents all points whose distance from this geometry is less than or equal to distance. 
        /// https://postgis.net/docs/manual-3.0/ST_Buffer.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <param name="radius">Buffer radius</param>
        /// <returns>Geometry</returns>
        [Sql.Function("ST_Buffer", ServerSideOnly = true)]
        public static NTSG STBuffer(this NTSG geometry, double radius)
        {
            throw new InvalidOperationException();
        }
    }
}