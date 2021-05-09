using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Validation.
    /// </summary>
    /// <remarks>
    /// 8.6. Geometry Validation
    /// https://postgis.net/docs/reference.html#Geometry_Validation
    /// </remarks>
    public static class GeometryValidation
    {
        /// <summary>
        /// Tests if input <paramref name="geometry"/> is well-formed in 2D according to the OGC rules.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>True if input <paramref name="geometry"/> is valid; otherwise false.</returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool? STIsValid(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Tests if input <paramref name="geometry"/> in text representation is well-formed in 2D according to the OGC rules.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>True if input <paramref name="geometry"/> is valid; otherwise false.</returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool? STIsValid(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Tests if input <paramref name="geometry"/> is well-formed in 2D according to the OGC rules.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="flags">Consider self-intersecting rings forming holes as valid = 1.</param>
        /// <returns>True if input <paramref name="geometry"/> is valid; otherwise false.</returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool? STIsValid(this NTSG geometry, int flags)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Tests if input <paramref name="geometry"/> in text representation is well-formed in 2D according to the OGC rules.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="flags">Consider self-intersecting rings forming holes as valid = 1.</param>
        /// <returns>True if input <paramref name="geometry"/> is valid; otherwise false.</returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool? STIsValid(string geometry, int flags)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns details of input <paramref name="geometry"/> validation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidDetail.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Details of validation.</returns>
        [Sql.Function("ST_IsValidDetail", ServerSideOnly = true)]
        public static ValidDetail STIsValidDetail(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns details of input <paramref name="geometry"/> in text representation validation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidDetail.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Details of validation.</returns>
        [Sql.Function("ST_IsValidDetail", ServerSideOnly = true)]
        public static ValidDetail STIsValidDetail(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns details of input <paramref name="geometry"/> validation.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidDetail.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="flags">Consider self-intersecting rings forming holes as valid = 1.</param>
        /// <returns>Details of validation.</returns>
        [Sql.Function("ST_IsValidDetail", ServerSideOnly = true)]
        public static ValidDetail STIsValidDetail(this NTSG geometry, int flags)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns text stating if input <paramref name="geometry"/> is valid or not an if not valid, a reason why.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidReason.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Valid message or reason if invalid.</returns>
        [Sql.Function("ST_IsValidReason", ServerSideOnly = true)]
        public static string STIsValidReason(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns text stating if input <paramref name="geometry"/> in text representation is valid or not an if not valid, a reason why.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidReason.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Valid message or reason if invalid.</returns>
        [Sql.Function("ST_IsValidReason", ServerSideOnly = true)]
        public static string STIsValidReason(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns text stating if input <paramref name="geometry"/> in text representation is valid or not an if not valid, a reason why.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidReason.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="flags">Consider self-intersecting rings forming holes as valid = 1.</param>
        /// <returns>Valid message or reason if invalid.</returns>
        [Sql.Function("ST_IsValidReason", ServerSideOnly = true)]
        public static string STIsValidReason(string geometry, int flags)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns text stating if input <paramref name="geometry"/> is valid or not an if not valid, a reason why.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_IsValidReason.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="flags">Consider self-intersecting rings forming holes as valid = 1.</param>
        /// <returns>Valid message or reason if invalid.</returns>
        [Sql.Function("ST_IsValidReason", ServerSideOnly = true)]
        public static string STIsValidReason(this NTSG geometry, int flags)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Attempts to create a valid representation of input invalid <paramref name="geometry"/> without losing any of input vertices.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakeValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Fixed (if possible) geometry.</returns>
        [Sql.Function("ST_MakeValid", ServerSideOnly = true)]
        public static NTSG STMakeValid(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Attempts to create a valid representation of input invalid <paramref name="geometry"/> in text representation without losing any of input vertices.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_MakeValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Fixed (if possible) geometry.</returns>
        [Sql.Function("ST_MakeValid", ServerSideOnly = true)]
        public static NTSG STMakeValid(string geometry)
        {
            throw new InvalidOperationException();
        }
    }
}
