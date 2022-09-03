using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Linear Referencing.
    /// </summary>
    /// <remarks>
    /// 5.18. Linear Referencing
    /// https://postgis.net/docs/reference.html#Linear_Referencing
    /// </remarks>
    public static class LinearReferencing
    {
#pragma warning disable IDE0060
        /// <summary>
        /// Returns Point interpolated along given line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineInterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Line geometry (LineString).</param>
        /// <param name="fraction">Fraction of total line length the point has to be located, between 0 and 1.</param>
        /// <returns>Point interpolated along the line.</returns>
        [Sql.Function("ST_LineInterpolatePoint", ServerSideOnly = true)]
        public static NTSG STLineInterpolatePoint(this NTSG geometry, double fraction) => throw new InvalidOperationException();

        /// <summary>
        /// Returns Point interpolated along given line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineInterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Line geometry (LineString).</param>
        /// <param name="fraction">Fraction of total line length the point has to be located, between 0 and 1.</param>
        /// <returns>Point interpolated along the line.</returns>
        [Sql.Function("ST_LineInterpolatePoint", ServerSideOnly = true)]
        public static NTSG STLineInterpolatePoint(string geometry, double fraction) => throw new InvalidOperationException();

        /// <summary>
        /// Returns Point interpolated along given 3D line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DLineInterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="fraction">Fraction of total linestring length the point has to be located, between 0 and 1.</param>
        /// <returns>Point interpolated along given 3D line.</returns>
        [Sql.Function("ST_3DLineInterpolatePoint", ServerSideOnly = true)]
        public static NTSG ST3DLineInterpolatePoint(this NTSG geometry, double fraction) => throw new InvalidOperationException();

        /// <summary>
        /// Returns Point interpolated along given 3D line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_3DLineInterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="fraction">Fraction of total linestring length the point has to be located, between 0 and 1.</param>
        /// <returns>Point interpolated along given 3D line.</returns>
        [Sql.Function("ST_3DLineInterpolatePoint", ServerSideOnly = true)]
        public static NTSG ST3DLineInterpolatePoint(string geometry, double fraction) => throw new InvalidOperationException();

        /// <summary>
        /// Returns one or more points interpolated along given line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineInterpolatePoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="fraction">Spacing between the points as a fraction of total line length, between 0 and 1.</param>
        /// <param name="repeat">Repeat, if false, at most one point will be constructed.</param>
        /// <returns>One or more Points interpolated along the line (Point or MultiPoint).</returns>
        [Sql.Function("ST_LineInterpolatePoints", ServerSideOnly = true)]
        public static NTSG STLineInterpolatePoints(this NTSG geometry, double fraction, bool repeat) => throw new InvalidOperationException();

        /// <summary>
        /// Returns one or more points interpolated along given line.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineInterpolatePoints.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="fraction">Spacing between the points as a fraction of total line length, between 0 and 1.</param>
        /// <param name="repeat">Repeat, if false, at most one point will be constructed.</param>
        /// <returns>One or more Points interpolated along the line (Point or MultiPoint).</returns>
        [Sql.Function("ST_LineInterpolatePoints", ServerSideOnly = true)]
        public static NTSG STLineInterpolatePoints(string geometry, double fraction, bool repeat) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a float value between 0 and 1 representing the location of the closest point on input geometry to the given <paramref name="point"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineLocatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="point">Point.</param>
        /// <returns>Float value between 0 and 1 representing the location of the closest point on input geometry to the given <paramref name="point"/>, as a fraction of total 2D line length.</returns>
        [Sql.Function("ST_LineLocatePoint", ServerSideOnly = true)]
        public static double? STLineLocatePoint(this NTSG geometry, NTSG point) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a float value between 0 and 1 representing the location of the closest point on input geometry to the given <paramref name="point"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineLocatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="point">Point.</param>
        /// <returns>Float value between 0 and 1 representing the location of the closest point on input geometry to the given <paramref name="point"/>, as a fraction of total 2D line length.</returns>
        [Sql.Function("ST_LineLocatePoint", ServerSideOnly = true)]
        public static double? STLineLocatePoint(string geometry, string point) => throw new InvalidOperationException();

        /// <summary>
        /// Returns LineString being a substring of the input <paramref name="geometry"/> starting and ending at the given fractions of total 2D length.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineSubstring.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="startFraction">Start fraction, between 0 and 1.</param>
        /// <param name="endFraction">End fraction, between 0 and 1.</param>
        /// <returns>LineString being a substring of the input one starting and ending at the given fractions of total 2D length.</returns>
        [Sql.Function("ST_LineSubstring", ServerSideOnly = true)]
        public static NTSG STLineSubstring(this NTSG geometry, double startFraction, double endFraction) => throw new InvalidOperationException();

        /// <summary>
        /// Returns LineString being a substring of the input <paramref name="geometry"/> starting and ending at the given fractions of total 2D length.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineSubstring.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString).</param>
        /// <param name="startFraction">Start fraction, between 0 and 1.</param>
        /// <param name="endFraction">End fraction, between 0 and 1.</param>
        /// <returns>LineString being a substring of the input one starting and ending at the given fractions of total 2D length.</returns>
        [Sql.Function("ST_LineSubstring", ServerSideOnly = true)]
        public static NTSG STLineSubstring(string geometry, double startFraction, double endFraction) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a derived geometry collection value with elements that match the specified measure.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LocateAlong.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="measure">Measure.</param>
        /// <param name="offset">Offset.</param>
        /// <returns>Derived geometry collection value with elements that match the specified measure.</returns>
        [Sql.Function("ST_LocateAlong", ServerSideOnly = true)]
        public static NTSG STLocateAlong(this NTSG geometry, double measure, double offset) => throw new InvalidOperationException();

        /// <summary>
        /// Returns a derived geometry collection value with elements that match the specified measure.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LocateAlong.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="measure">Measure.</param>
        /// <param name="offset">Offset.</param>
        /// <returns>Derived geometry collection value with elements that match the specified measure.</returns>
        [Sql.Function("ST_LocateAlong", ServerSideOnly = true)]
        public static NTSG STLocateAlong(string geometry, double measure, double offset) => throw new InvalidOperationException();

        /// <summary>
        /// Return a derived geometry collection with elements that match the specified range of measures inclusively.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LocateBetween.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="measureStart">Measure start.</param>
        /// <param name="measureEnd">Measure end.</param>
        /// <param name="offset">Offset.</param>
        /// <returns>Derived geometry collection with elements that match the specified range of measures inclusively.</returns>
        [Sql.Function("ST_LocateBetween", ServerSideOnly = true)]
        public static NTSG STLocateBetween(this NTSG geometry, double measureStart, double measureEnd, double offset) => throw new InvalidOperationException();

        /// <summary>
        /// Return a derived geometry collection with elements that match the specified range of measures inclusively.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LocateBetween.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="measureStart">Measure start.</param>
        /// <param name="measureEnd">Measure end.</param>
        /// <param name="offset">Offset.</param>
        /// <returns>Derived geometry collection with elements that match the specified range of measures inclusively.</returns>
        [Sql.Function("ST_LocateBetween", ServerSideOnly = true)]
        public static NTSG STLocateBetween(string geometry, double measureStart, double measureEnd, double offset) => throw new InvalidOperationException();

        /// <summary>
        /// Return a derived geometry collection with elements that intersect the specified range of elevations inclusively.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LocateBetweenElevations.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="elevationStart">Elevation start.</param>
        /// <param name="elevationEnd">Elevation end.</param>
        /// <returns>Derived geometry (collection) value with elements that intersect the specified range of elevations inclusively.</returns>
        [Sql.Function("ST_LocateBetweenElevations", ServerSideOnly = true)]
        public static NTSG STLocateBetweenElevations(this NTSG geometry, double elevationStart, double elevationEnd) => throw new InvalidOperationException();

        /// <summary>
        /// Returns derived geometry collection with elements that intersect the specified range of elevations inclusively.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LocateBetweenElevations.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="elevationStart">Elevation start.</param>
        /// <param name="elevationEnd">Elevation end.</param>
        /// <returns>Derived geometry (collection) value with elements that intersect the specified range of elevations inclusively.</returns>
        [Sql.Function("ST_LocateBetweenElevations", ServerSideOnly = true)]
        public static NTSG STLocateBetweenElevations(string geometry, double elevationStart, double elevationEnd) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the value of the measure dimension of geometry at the point close to the given <paramref name="point"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_InterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="point">Given point.</param>
        /// <returns>The value of the measure dimension of a geometry at the point closed to the provided point.</returns>
        [Sql.Function("ST_InterpolatePoint", ServerSideOnly = true)]
        public static double? STInterpolatePoint(this NTSG geometry, NTSG point) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the value of the measure dimension of geometry at the point close to the given <paramref name="point"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_InterpolatePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="point">Given point.</param>
        /// <returns>The value of the measure dimension of a geometry at the point closed to the provided point.</returns>
        [Sql.Function("ST_InterpolatePoint", ServerSideOnly = true)]
        public static double? STInterpolatePoint(string geometry, string point) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the derived geometry with measure elements linearly interpolated between the start and end points.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AddMeasure.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="measureStart">Measure start.</param>
        /// <param name="measureEnd">Measure end.</param>
        /// <returns>The value of the measure dimension of a geometry at the point closed to the provided point.</returns>
        [Sql.Function("ST_AddMeasure", ServerSideOnly = true)]
        public static NTSG STAddMeasure(this NTSG geometry, double measureStart, double measureEnd) => throw new InvalidOperationException();

        /// <summary>
        /// Returns the derived geometry with measure elements linearly interpolated between the start and end points.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AddMeasure.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="measureStart">Measure start.</param>
        /// <param name="measureEnd">Measure end.</param>
        /// <returns>The value of the measure dimension of a geometry at the point closed to the provided point.</returns>
        [Sql.Function("ST_AddMeasure", ServerSideOnly = true)]
        public static NTSG STAddMeasure(string geometry, double measureStart, double measureEnd) => throw new InvalidOperationException();
#pragma warning restore IDE0060
    }
}
