using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Spatial Reference System Functions.
    /// </summary>
    /// <remarks>
    /// 5.7. Spatial Reference System Functions 
    /// https://postgis.net/docs/reference.html#SRS_Functions
    /// </remarks>
    public static class SpatialReferenceSystemFunctions
    {
        /// <summary>
        /// Sets the SRID on the input <paramref name="geometry"/> to particular <paramref name="srid" />.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SetSRID.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="srid">Spatial Reference System Identifier.</param>
        /// <returns>Geometry with new SRID value.</returns>
        [Sql.Function("ST_SetSRID", ServerSideOnly = true)]
        public static NTSG STSetSrId(this NTSG geometry, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the SRID for the input <paramref name="geometry"/> as defined in spatial_ref_sys table.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SRID.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Spatial Reference System Identifier.</returns>
        [Sql.Function("ST_SRID", ServerSideOnly = true)]
        public static int? STSrId(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns new geometry with coordinates transformed to a different spatial reference system.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Transform.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="srid">Destination Spatial Reference System Identifier.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static NTSG STTransform(this NTSG geometry, int srid)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns new geometry with coordinates transformed to a different spatial reference system.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Transform.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="toProj">Destination spatial reference system defined as PROJ.4 string.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static NTSG STTransform(this NTSG geometry, string toProj)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns new geometry with coordinates transformed to a different spatial reference system.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Transform.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="fromProj">Input spatial reference system defined as PROJ.4 string.</param>
        /// <param name="toProj">Destination spatial reference system defined as PROJ.4 string.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static NTSG STTransform(this NTSG geometry, string fromProj, string toProj)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns new geometry with coordinates transformed to a different spatial reference system.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Transform.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="fromProj">Input spatial reference defined as PROJ.4 string.</param>
        /// <param name="toSrid">Destination Spatial Reference System Identifier.</param>
        /// <returns>Transformed geometry.</returns>
        [Sql.Function("ST_Transform", ServerSideOnly = true)]
        public static NTSG STTransform(this NTSG geometry, string fromProj, int toSrid)
        {
            throw new InvalidOperationException();
        }
    }
}
