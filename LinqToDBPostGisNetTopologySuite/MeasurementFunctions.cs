using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    // Chapter 8. PostGIS Reference
    // https://postgis.net/docs/manual-3.0/reference.html

    /// <summary>
    /// 8.12. Measurement Functions
    /// https://postgis.net/docs/manual-3.0/reference.html#Measurement_Functions
    /// </summary>
    public static class MeasurementFunctions
    {
        /// <summary>
        /// Returns the area of a polygonal geometry. For geometry types a 2D Cartesian (planar) area is computed, with units specified by the SRID.
        /// https://postgis.net/docs/manual-3.0/ST_Area.html
        /// </summary>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Area</returns>
        [Sql.Function("ST_Area", ServerSideOnly = true)]
        public static double STArea(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// For geometry types returns the minimum 2D Cartesian (planar) distance between two geometries, in projected units (spatial ref units).
        /// https://postgis.net/docs/manual-3.0/ST_Distance.html
        /// </summary>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Distance between two geometries</returns>
        [Sql.Function("ST_Distance", ServerSideOnly = true)]
        public static double STDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }
    }
}