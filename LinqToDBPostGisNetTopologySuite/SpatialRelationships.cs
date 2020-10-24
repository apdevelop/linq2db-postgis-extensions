using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Spatial Relationships
    /// </summary>
    /// <remarks>
    /// 8.11. Spatial Relationships https://postgis.net/docs/manual-3.0/reference.html#Spatial_Relationships
    /// </remarks>
    public static class SpatialRelationships
    {
        /// <summary>
        /// Returns true if geometry 2 is completely inside geometry 1.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Contains.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is contains</returns>
        [Sql.Function("ST_Contains", ServerSideOnly = true)]
        public static bool STContains(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if no point in geometry 2 is outside geometry 1
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Covers.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is covers</returns>
        [Sql.Function("ST_Covers", ServerSideOnly = true)]
        public static bool STCovers(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Tests if two geometries shares any portion of space then they intersect.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Intersects.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is intersects</returns>
        [Sql.Function("ST_Intersects", ServerSideOnly = true)]
        public static bool STIntersects(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }
    }
}