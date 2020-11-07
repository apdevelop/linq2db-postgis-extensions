using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Spatial Reference System Functions
    /// </summary>
    /// <remarks>
    /// 8.7. Spatial Reference System Functions https://postgis.net/docs/manual-3.0/reference.html#SRS_Functions
    /// </remarks>
    public static class SpatialReferenceSystemFunctions
    {
        /// <summary>
        /// Returns the spatial reference identifier for the geometry as defined in spatial_ref_sys table.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_SRID.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Spatial Reference System Identifier</returns>
        [Sql.Function("ST_SRID", ServerSideOnly = true)]
        public static int? STSrId(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a new geometry with its coordinates transformed to a different spatial reference system.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Transform.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="srid">Spatial Reference System Identifier</param>
        /// <returns>Transformed geometry</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static NTSG STTransform(this NTSG geometry, int srid)
        {
            throw new InvalidOperationException();
        }
    }
}