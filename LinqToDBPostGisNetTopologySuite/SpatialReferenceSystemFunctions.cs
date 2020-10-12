using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    // Chapter 8. PostGIS Reference
    // https://postgis.net/docs/manual-3.0/reference.html

    /// <summary>
    /// 8.7. Spatial Reference System Functions
    /// https://postgis.net/docs/manual-3.0/reference.html#SRS_Functions
    /// </summary>
    public static class SpatialReferenceSystemFunctions
    {
        /// <summary>
        /// Returns the spatial reference identifier for the ST_Geometry as defined in spatial_ref_sys table.
        /// https://postgis.net/docs/manual-3.0/ST_SRID.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Spatial reference identifier</returns>
        [Sql.Function("ST_SRID", ServerSideOnly = true)]
        public static int STSrId(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a new geometry with its coordinates transformed to a different spatial reference system.
        /// https://postgis.net/docs/manual-3.0/ST_Transform.html
        /// </summary>
        /// <param name="geometry ">Input geometry</param>
        /// <param name="srid">Spatial reference system ID</param>
        /// <returns>Transformed geometry</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static NTSG STTransform(this NTSG geometry, int srid)
        {
            throw new InvalidOperationException();
        }
    }
}