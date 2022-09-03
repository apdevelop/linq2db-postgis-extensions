using NpgsqlTypes;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Mapping for valid_detail composite type.
    /// </summary>
    /// <remarks>
    /// See https://postgis.net/docs/ST_IsValidDetail.html
    /// </remarks>
    public class ValidDetail
    {
        /// <summary>
        /// Composite type name.
        /// </summary>
        public const string CompositeTypeName = "valid_detail";

        /// <summary>
        /// Stating if geometry is valid.
        /// </summary>
        [PgName("valid")]
        public bool IsValid { get; set; }

        /// <summary>
        /// Reason why geometry is invalid (null if valid geometry).
        /// </summary>
        [PgName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Pointing out where geometry is invalid (null if valid geometry).
        /// </summary>
        [PgName("location")]
        public NTSG Location { get; set; }
    }
}
