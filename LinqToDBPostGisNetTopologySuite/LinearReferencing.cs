using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;
using NTS = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Linear Referencing
    /// </summary>
    /// <remarks>
    /// 8.17. Linear Referencing https://postgis.net/docs/manual-3.0/reference.html#Linear_Referencing
    /// </remarks>
    public static class LinearReferencing
    {
        /// <summary>
        /// Returns a point interpolated along a line
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineInterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="fraction">Fraction of total linestring length the point has to be located,(Between 0 and 1)</param>
        /// <returns>A point interpolated along the line</returns>
        [Sql.Function("ST_LineInterpolatePoint", ServerSideOnly = true)]
        public static NTSG STLineInterpolatePoint(this NTSG geometry, double fraction)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a point interpolated along a line
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_3DLineInterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="fraction">Fraction of total linestring length the point has to be located(Between 0 and 1)</param>
        /// <returns>a point interpolated along the line</returns>
        [Sql.Function("ST_3DLineInterpolatePoint", ServerSideOnly = true)]
        public static NTSG ST3DLineInterpolatePoint(this NTSG geometry, double fraction)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns one or more points interpolated along a line.If repeat is false, at most one point will be constructed
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineInterpolatePoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="fraction">Spacing between the points as a fraction of total LineString length(Between 0 and 1)</param>
        /// <param name="repeat">Repeat</param>
        /// <returns>One or more points interpolated along the line</returns>
        [Sql.Function("ST_LineInterpolatePoints", ServerSideOnly = true)]
        public static NTSG STLineInterpolatePoints(this NTSG geometry, double fraction, bool repeat)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a float between 0 and 1 representing the location of the closest point on LineString to the given Point, as a fraction of total 2d line length
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineLocatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="point">Given point</param>
        /// <returns>A float between 0 and 1 representing the location of the closest point on LineString to the given Point</returns>
        [Sql.Function("ST_LineLocatePoint", ServerSideOnly = true)]
        public static double? STLineLocatePoint(this NTSG geometry, NTSG point)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a linestring being a substring of the input one starting and ending at the given fractions of total 2d length
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LineSubstring.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="startFraction">Startfraction(Between 0 and 1)</param>
        /// <param name="endFraction">Endfraction(Between 0 and 1)</param>
        /// <returns>Linestring being a substring of the input one starting and ending at the given fractions of total 2d length</returns>
        [Sql.Function("ST_LineSubstring", ServerSideOnly = true)]
        public static NTSG STLineSubstring(this NTSG geometry, double startFraction, double endFraction)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a derived geometry collection value with elements that match the specified measure(Polygonal elements are not supported).Resultant will be offset to the left(When offset is positive) or right(When offset is negative) of the input line by the specified number of units
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LocateAlong.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="measure">Measure</param>
        /// <param name="offset">Offset</param>
        /// <returns>Derived geometry collection value with elements that match the specified measure</returns>
        [Sql.Function("ST_LocateAlong", ServerSideOnly = true)]
        public static NTSG STLocateAlong(this NTSG geometry, double measure, double offset)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a derived geometry collection with elements that match the specified range of measures inclusively.The resultant will be offset to the left(When offset is positive) or right(When offset is negative) of the input line by the specified number of units
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LocateBetween.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="measureStart">Measure start</param>
        /// <param name="measureEnd">Measure end</param>
        /// <param name="offset">Offset</param>
        /// <returns>Derived geometry collection with elements that match the specified range of measures inclusively</returns>
        [Sql.Function("ST_LocateBetween", ServerSideOnly = true)]
        public static NTSG STLocateBetween(this NTSG geometry, double measureStart, double measureEnd, double offset)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a derived geometry (collection) value with elements that intersect the specified range of elevations inclusively
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_LocateBetweenElevations.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="elevationStart">Elevation start</param>
        /// <param name="elevationEnd">Elevation end</param>
        /// <returns>Derived geometry (collection) value with elements that intersect the specified range of elevations inclusively</returns>
        [Sql.Function("ST_LocateBetweenElevations", ServerSideOnly = true)]
        public static NTSG STLocateBetweenElevations(this NTSG geometry, double elevationStart, double elevationEnd)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return the value of the measure dimension of a geometry at the point closed to the provided point
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_InterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="point">Given point</param>
        /// <returns>The value of the measure dimension of a geometry at the point closed to the provided point</returns>
        [Sql.Function("ST_InterpolatePoint", ServerSideOnly = true)]
        public static double? STInterpolatePoint(this NTSG geometry, NTSG point)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return a derived geometry with measure elements linearly interpolated between the start and end points
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/manual-3.0/ST_AddMeasure.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <param name="measureStart">measureStart</param>
        /// <param name="measureEnd">measureEnd</param>
        /// <returns>The value of the measure dimension of a geometry at the point closed to the provided point</returns>
        [Sql.Function("ST_AddMeasure", ServerSideOnly = true)]
        public static NTSG STAddMeasure(this NTSG geometry, double measureStart, double measureEnd)
        {
            throw new InvalidOperationException();
        }
    }
}