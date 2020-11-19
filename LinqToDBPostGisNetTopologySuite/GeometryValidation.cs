using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Validation
    /// </summary>
    /// <remarks>
    /// 8.6. Geometry Validation https://postgis.net/docs/manual-3.0/reference.html#Geometry_Validation
    /// </remarks>
    public static class GeometryValidation
    {
        /// <summary>
        /// Returns true if input geometry is well-formed in 2D according to the OGC rules.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry is valid</returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool? STIsValid(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if input geometry is well-formed in 2D according to the OGC rules.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="flags">Consider self-intersecting rings forming holes as valid = 1</param>
        /// <returns>Geometry is valid</returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool? STIsValid(this NTSG geometry, int flags)
        {
            throw new InvalidOperationException();
        }

        // TODO: ST_IsValidDetail return type: row, how to use with linq2db ?

        /// <summary>
        /// Returns text stating if input geometry is valid or not an if not valid, a reason why.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsValidReason.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Valid message or reason if invalid</returns>
        [Sql.Function("ST_IsValidReason", ServerSideOnly = true)]
        public static string STIsValidReason(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns text stating if input geometry is valid or not an if not valid, a reason why.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsValidReason.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="flags">Consider self-intersecting rings forming holes as valid = 1</param>
        /// <returns>Valid message or reason if invalid</returns>
        [Sql.Function("ST_IsValidReason", ServerSideOnly = true)]
        public static string STIsValidReason(this NTSG geometry, int flags)
        {
            throw new InvalidOperationException();
        }
    }
}