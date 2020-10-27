using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Editors
    /// </summary>
    /// <remarks>
    /// 8.5. Geometry Editors https://postgis.net/docs/manual-3.0/reference.html#Geometry_Editors
    /// </remarks>
    public static class GeometryEditors
    {
        /// <summary>
        /// Returns geometry in its normalized/canonical form.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Normalize.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Normalized geometry</returns>
        [Sql.Function("ST_Normalize", ServerSideOnly = true)]
        public static NTSG STNormalize(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry with reversed order of the vertexes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Reverse.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry with reversed order of the vertexes</returns>
        [Sql.Function("ST_Reverse", ServerSideOnly = true)]
        public static NTSG STReverse(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}