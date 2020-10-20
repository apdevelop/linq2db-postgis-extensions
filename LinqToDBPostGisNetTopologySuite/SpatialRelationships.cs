using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    // Chapter 8. PostGIS Reference
    // https://postgis.net/docs/manual-3.0/reference.html

    /// <summary>
    /// 8.11. Spatial Relationships
    /// https://postgis.net/docs/manual-3.0/reference.html#Spatial_Relationships
    /// </summary>
    public static class SpatialRelationships
    {
        /// <summary>
        /// Returns TRUE if geometry 2 is completely inside geometry 1.
        /// https://postgis.net/docs/manual-3.0/ST_Contains.html
        /// </summary>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is contains</returns>
        [Sql.Function("ST_Contains", ServerSideOnly = true)]
        public static bool STContains(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns true if no point in other geometry 2 is outside geometry 1
        /// https://postgis.net/docs/manual-3.0/ST_Covers.html
        /// </summary>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Is intersects</returns>
        [Sql.Function("ST_Covers", ServerSideOnly = true)]
        public static bool STCovers(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Tests if two geometries shares any portion of space then they intersect.
        /// https://postgis.net/docs/manual-3.0/ST_Intersects.html
        /// </summary>
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