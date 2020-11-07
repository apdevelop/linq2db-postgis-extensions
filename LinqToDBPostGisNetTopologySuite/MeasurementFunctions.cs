using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Measurement Functions
    /// </summary>
    /// <remarks>
    /// 8.12. Measurement Functions https://postgis.net/docs/manual-3.0/reference.html#Measurement_Functions
    /// </remarks>
    public static class MeasurementFunctions
    {
        /// <summary>
        /// Returns the area of a polygonal geometry. For geometry types a 2D Cartesian (planar) area is computed, with units specified by the SRID.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Area.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Area</returns>
        [Sql.Function("ST_Area", ServerSideOnly = true)]
        public static double? STArea(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// For geometry types returns the minimum 2D Cartesian (planar) distance between two geometries, in projected units (spatial ref units).
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Distance.html
        /// </remarks>
        /// <param name="geometry">Input geometry 1</param>
        /// <param name="other">Input geometry 2</param>
        /// <returns>Distance between two geometries</returns>
        [Sql.Function("ST_Distance", ServerSideOnly = true)]
        public static double? STDistance(this NTSG geometry, NTSG other)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D Cartesian length of the geometry if it is a LineString, MultiLineString, ST_Curve, ST_MultiCurve. For areal geometries 0 is returned; use ST_Perimeter instead.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Length.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Length</returns>
        [Sql.Function("ST_Length", ServerSideOnly = true)]
        public static double? STLength(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the 2D perimeter of the geometry if it is a ST_Surface, ST_MultiSurface (Polygon, MultiPolygon). Zero is returned for non-areal geometries. For linear geometries use ST_Length.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_Perimeter.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Perimeter</returns>
        [Sql.Function("ST_Perimeter", ServerSideOnly = true)]
        public static double? STPerimeter(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }
    }
}