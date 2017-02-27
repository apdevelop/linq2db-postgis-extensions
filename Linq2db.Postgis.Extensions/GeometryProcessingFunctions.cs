using System;

using LinqToDB;
using NpgsqlTypes;

namespace Linq2db.Postgis.Extensions
{
    // http://postgis.refractions.net/documentation/manual-1.5/reference.html#Geometry_Processing

    public static class GeometryProcessingFunctions
    {
        /// <summary>
        /// The convex hull of a geometry represents the minimum convex geometry that encloses all geometries within the set.
        /// http://postgis.refractions.net/documentation/manual-1.5/ST_ConvexHull.html
        /// </summary>
        /// <param name="geom">Input geometry</param>
        /// <returns>The convex hull of a geometry</returns>
        [Sql.Function("ST_ConvexHull", ServerSideOnly = true)]
        public static PostgisGeometry StConvexHull(this PostgisGeometry geom)
        {
            throw new InvalidOperationException();
        }
    }
}
