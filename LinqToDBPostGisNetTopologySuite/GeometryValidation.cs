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
        /// Returns true if geometry value is well-formed in 2D according to the OGC rules. 
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_IsValid.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Is valid</returns>
        [Sql.Function("ST_IsValid", ServerSideOnly = true)]
        public static bool STIsValid(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}